namespace roslynviewer;

using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

public class SyntaxTriviaViewModel  : ITreeNodeViewModel
{
    public SyntaxTriviaViewModel(SyntaxTrivia trivia)
    {
        this.Node = trivia;
    }

    

    public SyntaxTrivia Node {get;}

    public Location GetLocation() => Node.GetLocation();

    public string KindText { get => this.Node.Kind().ToString();}

    public IReadOnlyList<ITreeNodeViewModel> Children => Array.Empty<ITreeNodeViewModel>();
}