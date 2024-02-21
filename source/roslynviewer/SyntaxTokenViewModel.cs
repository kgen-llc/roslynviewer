namespace roslynviewer;

using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

using CommunityToolkit.Mvvm.ComponentModel;

public class SyntaxTokenViewModel  : ObservableObject, ITreeNodeViewModel
{
    private IReadOnlyList<ITreeNodeViewModel>? children;

    public SyntaxTokenViewModel(SyntaxToken node)
    {
        this.Node = node;
    }

    private bool _isExpanded;
    public bool IsExpanded
    {
        get  => _isExpanded;
        set  => this.SetProperty(ref this._isExpanded, value);
    }

    public SyntaxToken Node {get;}

    public Location GetLocation() => Node.GetLocation();

    public string KindText { get => this.Node.Kind().ToString();}

    public IReadOnlyList<ITreeNodeViewModel> Children => this.children ??= new List<ITreeNodeViewModel>(InternalChildren);
    
    public IReadOnlyList<PropertyInfo> Properties => [
        new PropertyInfo("Type", "Token"),
        new PropertyInfo("Kind", KindText),
    ];

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
