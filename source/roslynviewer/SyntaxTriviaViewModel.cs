namespace roslynviewer;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

public class SyntaxTriviaViewModel  : ILocationProvider
{
public SyntaxTriviaViewModel(SyntaxTrivia trivia)
    {
        this.Node = trivia;
    }

    public SyntaxTrivia Node {get;}

    public Location GetLocation() => Node.GetLocation();

    public string KindText { get => this.Node.Kind().ToString();}
}