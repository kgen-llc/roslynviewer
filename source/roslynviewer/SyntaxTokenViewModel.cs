namespace roslynviewer;

using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

public class SyntaxTokenViewModel  : ILocationProvider
{

    public SyntaxTokenViewModel(SyntaxToken node)
    {
        this.Node = node;
    }

    public SyntaxToken Node {get;}

    public Microsoft.CodeAnalysis.Location GetLocation() => Node.GetLocation();

    public string KindText { get => this.Node.Kind().ToString();}

    public IEnumerable<object> Children {
        get => 
        (this.Node.HasLeadingTrivia 
            ? this.Node.LeadingTrivia.Select(SyntaxNodeViewModel.CreateViewModel)
            : Enumerable.Empty<object>() )
        .Concat((this.Node.HasTrailingTrivia 
            ? this.Node.TrailingTrivia.Select(SyntaxNodeViewModel.CreateViewModel)
            : Enumerable.Empty<object>() ));
    }
}
