using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using PassKeeper.CoreLib.Services;
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
                var storageService = new StorageService();
                desktop.MainWindow = new MainWindowView
                {
                    DataContext = new MainWindowViewModel(storageService) 

                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
