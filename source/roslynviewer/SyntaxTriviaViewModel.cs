namespace roslynviewer;

using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

using CommunityToolkit.Mvvm.ComponentModel;

public class SyntaxTriviaViewModel  : ObservableObject, ITreeNodeViewModel
{
    public SyntaxTriviaViewModel(SyntaxTrivia trivia)
    {
        this.Node = trivia;
    }

    private bool _isExpanded;
    public bool IsExpanded
    {
        get  => _isExpanded;
        set  => this.SetProperty(ref this._isExpanded, value);
    }
    

    public SyntaxTrivia Node {get;}

    public IReadOnlyList<PropertyInfo> Properties => [
        new PropertyInfo("Type", "Trivia"),
        new PropertyInfo("Kind", KindText),
        new PropertyInfo("Language", this.Node.Language),
        new PropertyInfo("Location", this.GetLocation().GetLineSpan().ToString()),
    ];

    public Location GetLocation() => Node.GetLocation();

    public string KindText { get => this.Node.Kind().ToString();}

    public IReadOnlyList<ITreeNodeViewModel> Children => [];
}