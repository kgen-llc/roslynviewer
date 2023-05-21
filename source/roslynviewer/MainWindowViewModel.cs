namespace roslynviewer;

using Avalonia.Controls.ApplicationLifetimes;

using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.CodeAnalysis.CSharp;

public class MainWindowViewModel  : ObservableObject 
{
    public MainWindowViewModel(IControlledApplicationLifetime controlledApplicationLifetime) {
        this.controlledApplicationLifetime = controlledApplicationLifetime;
        this.sourceCode = string.Empty;
        this.syntaxTreeRoot = new List<SyntaxNodeViewModel> ();
    }
    private string sourceCode;
    private  List<SyntaxNodeViewModel> syntaxTreeRoot;
    private readonly IControlledApplicationLifetime controlledApplicationLifetime;

    public string SourceCode {
        get => this.sourceCode;

        set {
            if(this.SetProperty(ref this.sourceCode, value)) {
                this.SyntaxTreeRoot = new List<SyntaxNodeViewModel> { 
                    new SyntaxNodeViewModel(CSharpSyntaxTree.ParseText(this.sourceCode).GetRoot())
                };
            }
        }
    }

    public List<SyntaxNodeViewModel> SyntaxTreeRoot {
        get => this.syntaxTreeRoot;
        set => this.SetProperty(ref this.syntaxTreeRoot, value);
    }

    public void ExitCommand() {
        this.controlledApplicationLifetime.Shutdown(0);
    }
}
