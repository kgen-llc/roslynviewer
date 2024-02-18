namespace roslynviewer;

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using CommunityToolkit.Mvvm.ComponentModel;

public class SyntaxNodeViewModel : ObservableObject, ITreeNodeViewModel
{
    private IReadOnlyList<ITreeNodeViewModel>? children;

    public SyntaxNodeViewModel(SyntaxNode node)
    {
        this.Node = node;
    }

    private bool _isExpanded;
    public bool IsExpanded
    {
        get  => _isExpanded;
        set  => this.SetProperty(ref this._isExpanded, value);
    }

    public SyntaxNode Node {get;}

    public Location GetLocation() => Node.GetLocation();

    public IReadOnlyList<ITreeNodeViewModel> Children => this.children ??= new List<ITreeNodeViewModel>(InternalChildren);
    

    private IEnumerable<ITreeNodeViewModel> InternalChildren {
        get => 
        (this.Node.HasLeadingTrivia 
            ? this.Node.GetLeadingTrivia().Select(CreateViewModel)
            : Enumerable.Empty<ITreeNodeViewModel>() )
        .Concat(this.Node.ChildNodesAndTokens().Select(CreateViewModel))
        .Concat((this.Node.HasTrailingTrivia 
            ? this.Node.GetTrailingTrivia().Select(CreateViewModel)
            : Enumerable.Empty<ITreeNodeViewModel>() ));
    }

    public static ITreeNodeViewModel CreateViewModel(SyntaxTrivia trivia) {
        return new SyntaxTriviaViewModel(trivia);
    }

    public static ITreeNodeViewModel CreateViewModel(SyntaxNodeOrToken nodeOrToken) {
        if(nodeOrToken.IsNode) {
            return new SyntaxNodeViewModel(nodeOrToken.AsNode()!);
        }
        if(nodeOrToken.IsToken) {
            return new SyntaxTokenViewModel(nodeOrToken.AsToken());
        }
        throw new NotImplementedException();
    }

    
}
