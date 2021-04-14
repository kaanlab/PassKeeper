using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using PassKeeper.Desktop.ViewModels;
using PassKeeper.Desktop.Views;
using ReactiveUI;
using Splat;

namespace PassKeeper.Desktop
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindowView
                {
                    DataContext = new MainWindowViewModel() 

                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
