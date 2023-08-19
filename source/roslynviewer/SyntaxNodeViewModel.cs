namespace roslynviewer;

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;

public interface ILocationProvider {
    Microsoft.CodeAnalysis.Location GetLocation();
}

public class SyntaxNodeViewModel : ILocationProvider
{
    public SyntaxNodeViewModel(SyntaxNode node)
    {
        this.Node = node;
    }

    public SyntaxNode Node {get;}

    public Microsoft.CodeAnalysis.Location GetLocation() => Node.GetLocation();

    public IEnumerable<object> Children {
        get => 
        (this.Node.HasLeadingTrivia 
            ? this.Node.GetLeadingTrivia().Select(CreateViewModel)
            : Enumerable.Empty<object>() )
        .Concat(this.Node.ChildNodesAndTokens().Select(CreateViewModel))
        .Concat((this.Node.HasTrailingTrivia 
            ? this.Node.GetTrailingTrivia().Select(CreateViewModel)
            : Enumerable.Empty<object>() ));
    }

    public static object CreateViewModel(SyntaxTrivia trivia) {
        return new SyntaxTriviaViewModel(trivia);
    }

    public static object CreateViewModel(SyntaxNodeOrToken nodeOrToken) {
        if(nodeOrToken.IsNode) {
            return new SyntaxNodeViewModel(nodeOrToken.AsNode()!);
        }
        if(nodeOrToken.IsToken) {
            return new SyntaxTokenViewModel(nodeOrToken.AsToken());
        }
        throw new NotImplementedException();
    }
}
