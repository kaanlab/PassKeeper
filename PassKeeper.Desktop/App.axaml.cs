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
            // Here we register our view models.
            Locator.CurrentMutable.RegisterConstant<IScreen>(new MainWindowViewModel());
            Locator.CurrentMutable.Register<IViewFor<CadetsViewModel>>(() => new CadetsView());
            Locator.CurrentMutable.Register<IViewFor<PasswordsViewModel>>(() => new PasswordsView());

            // Here we resolve the root view model and initialize main view data context.
            new MainWindowView { DataContext = Locator.Current.GetService<IScreen>() }.Show();

            base.OnFrameworkInitializationCompleted();
        }
    }
}
