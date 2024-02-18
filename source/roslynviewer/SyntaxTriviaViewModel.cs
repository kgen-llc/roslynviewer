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

    private bool _isExpanded = false;
    public bool IsExpanded
    {
        get  => _isExpanded;
        set  => this.SetProperty(ref this._isExpanded, value);
    }
    

    public SyntaxTrivia Node {get;}

    public Location GetLocation() => Node.GetLocation();

    public string KindText { get => this.Node.Kind().ToString();}

    public IReadOnlyList<ITreeNodeViewModel> Children => Array.Empty<ITreeNodeViewModel>();
}