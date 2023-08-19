namespace roslynviewer;

using Avalonia.Controls;
using AvaloniaEdit.TextMate;
using TextMateSharp.Grammars;

using Avalonia.Controls.ApplicationLifetimes;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

         SetupMate();
    }

    public void SetupMate() {
        var registryOptions = new RegistryOptions(ThemeName.Light);

         var textMateInstallation = this.Editor.InstallTextMate(registryOptions);
         textMateInstallation.SetGrammar(
            registryOptions.GetScopeByLanguageId(
                registryOptions.GetLanguageByExtension(".cs").Id
            )
        );
    }

    public void InitDataContext(IControlledApplicationLifetime controlledApplicationLifetime) {
        var viewModel = new MainWindowViewModel(controlledApplicationLifetime);

        bindingText();

        bindingSelection();

        this.DataContext = viewModel;

        void bindingText() {
            this.Editor.TextChanged += (_, __) => {
                viewModel.SourceCode = this.Editor.Text;
            };
        }

        void bindingSelection() {
            this.tree.PropertyChanged += (sender, args) => {
                if(args.Property.Name == nameof(this.tree.SelectedItem)
                    && this.tree.SelectedItem is ILocationProvider locationProvider) {
                    
                    var location = locationProvider.GetLocation().SourceSpan;

                    this.Editor.TextArea.Selection = AvaloniaEdit.Editing.Selection.Create(this.Editor.TextArea, location.Start, location.End);
                }
            };
        }
    }
}
