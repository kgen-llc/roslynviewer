namespace roslynviewer.tests;

using Microsoft.CodeAnalysis.CSharp;
using roslynviewer;

[TestClass]
public class UnitTests : VerifyBase
{
    [TestMethod]
    public async Task OverallSyntaxNodeViewModel()
    {
        // arrange
        var sourceCode = @"// Hello World! program
namespace HelloWorld
{
    class Hello {         
        static void Main(string[] args)
        {
            System.Console.WriteLine(""Hello World!"");
        }
    }
}";

        // act
        var root = new SyntaxNodeViewModel(CSharpSyntaxTree.ParseText(sourceCode).GetRoot());

        // assert
        await Verify(root).ScrubMember(nameof(SyntaxNodeViewModel.Node));
    }
}