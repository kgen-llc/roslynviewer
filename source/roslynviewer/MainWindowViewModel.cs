namespace roslynviewer;

using Avalonia.Controls.ApplicationLifetimes;

using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.CodeAnalysis.CSharp;
using System.Reflection;
using System.Linq;
using AvaloniaEdit;

public class MainWindowViewModel : ObservableObject
{
    public MainWindowViewModel(IControlledApplicationLifetime controlledApplicationLifetime)
    {
        this.controlledApplicationLifetime = controlledApplicationLifetime;
        this.sourceCode = string.Empty;
        this.syntaxTreeRoot = new List<SyntaxNodeViewModel>();

        this.ApplicationTitle = getTitle();

        static string getTitle()
        {
            var assembly = Assembly.GetEntryAssembly()!;

            return assembly.GetCustomAttribute<AssemblyProductAttribute>()!.Product + " " + withShortSha(assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()!.InformationalVersion)
                + " - " + assembly.GetCustomAttribute<AssemblyCopyrightAttribute>()!.Copyright;
        }

        static string withShortSha(string version) => version[..(version.IndexOf('+', System.StringComparison.OrdinalIgnoreCase)+7)];
    }
    private string sourceCode;
    private IReadOnlyCollection<SyntaxNodeViewModel> syntaxTreeRoot;

    private readonly IControlledApplicationLifetime controlledApplicationLifetime;

    public string SourceCode
    {
        get => this.sourceCode;

        set
        {
            if (this.SetProperty(ref this.sourceCode, value))
            {
                this.SyntaxTreeRoot = new List<SyntaxNodeViewModel> {
                    new SyntaxNodeViewModel(CSharpSyntaxTree.ParseText(this.sourceCode).GetRoot())
                };
            }
        }
    }

    public IReadOnlyCollection<SyntaxNodeViewModel> SyntaxTreeRoot
    {
        get => this.syntaxTreeRoot;
        set => this.SetProperty(ref this.syntaxTreeRoot, value);
    }

    private ITreeNodeViewModel? selectedItem;

    public ITreeNodeViewModel? SelectedItem 
    {
        get => this.selectedItem;
        set => this.SetProperty(ref this.selectedItem, value);
    }

    public string ApplicationTitle { get; }

    public void ExitCommand()
    {
        this.controlledApplicationLifetime.Shutdown(0);
    }

    public static void AboutCommand()
    {
        "https://github.com/kgen-llc/roslynviewer".OpenUrl();
    }

    public void LocateInSyntaxTreeCommand(object textEditor)
    {
        if(textEditor != null)  {
            var offset = ((TextEditor)textEditor).CaretOffset;

            this.SelectedItem = FindNode(SyntaxTreeRoot.First(), offset);
        }
    }


    public static ITreeNodeViewModel? FindNode(ITreeNodeViewModel node, int offset)
    {
        if (node == null || !node.Children.Any())
        {
            return node;
        }
        
        node.IsExpanded = true;

        foreach (var child in node.Children)
        {
            if (child.GetLocation().SourceSpan.Contains(offset))
            {
                return FindNode(child, offset);
            }
        }

        return node;
    }
}
