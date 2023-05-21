namespace roslynviewer;

using Avalonia.Controls;

using Avalonia.Controls.ApplicationLifetimes;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
    }

    public void InitDataContext(IControlledApplicationLifetime controlledApplicationLifetime) {
        this.DataContext = new MainWindowViewModel(controlledApplicationLifetime);
    }
}
