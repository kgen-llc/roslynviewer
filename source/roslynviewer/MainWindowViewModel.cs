namespace roslynviewer;

using Avalonia.Controls.ApplicationLifetimes;

using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.CodeAnalysis.CSharp;
using System.Reflection;

public class MainWindowViewModel  : ObservableObject 
{
    public MainWindowViewModel(IControlledApplicationLifetime controlledApplicationLifetime) {
        this.controlledApplicationLifetime = controlledApplicationLifetime;
        this.sourceCode = string.Empty;
        this.syntaxTreeRoot = new List<SyntaxNodeViewModel> ();

        this.ApplicationTitle = getTitle();

        static string getTitle()
        {
            var assembly= Assembly.GetEntryAssembly()!;

            return assembly.GetCustomAttribute<AssemblyProductAttribute>()!.Product + " " + assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()!.InformationalVersion.ToString()
                + " - " + assembly.GetCustomAttribute<AssemblyCopyrightAttribute>()!.Copyright;
        }
    }
    private string sourceCode;
    private IReadOnlyCollection<SyntaxNodeViewModel> syntaxTreeRoot;
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

    public IReadOnlyCollection<SyntaxNodeViewModel> SyntaxTreeRoot {
        get => this.syntaxTreeRoot;
        set => this.SetProperty(ref this.syntaxTreeRoot, value);
    }

    public string ApplicationTitle { get; } 

    public void ExitCommand() {
        this.controlledApplicationLifetime.Shutdown(0);
    }

    public static void AboutCommand() {
        "https://github.com/kgen-llc/roslynviewer".OpenUrl();
    }
}
