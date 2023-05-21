namespace roslynviewer;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

public class SyntaxTriviaViewModel 
{
public SyntaxTriviaViewModel(SyntaxTrivia trivia)
    {
        this.Node = trivia;
    }

    public SyntaxTrivia Node {get;}

    public string KindText { get => this.Node.Kind().ToString();}
}