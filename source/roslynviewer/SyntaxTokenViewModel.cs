namespace roslynviewer;

using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

public class SyntaxTokenViewModel  : ITreeNodeViewModel
{
    private IReadOnlyList<ITreeNodeViewModel>? children;

    public SyntaxTokenViewModel(SyntaxToken node)
    {
        this.Node = node;
    }

    public SyntaxToken Node {get;}

    public Location GetLocation() => Node.GetLocation();

    public string KindText { get => this.Node.Kind().ToString();}

    public IReadOnlyList<ITreeNodeViewModel> Children => this.children ??= new List<ITreeNodeViewModel>(InternalChildren);
    
    private IEnumerable<ITreeNodeViewModel> InternalChildren {
        get => 
        (this.Node.HasLeadingTrivia 
            ? this.Node.LeadingTrivia.Select(SyntaxNodeViewModel.CreateViewModel)
            : Enumerable.Empty<ITreeNodeViewModel>() )
        .Concat(this.Node.HasTrailingTrivia 
            ? this.Node.TrailingTrivia.Select(SyntaxNodeViewModel.CreateViewModel)
            : Enumerable.Empty<ITreeNodeViewModel>() );
    }
}
