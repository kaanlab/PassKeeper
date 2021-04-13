using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using PassKeeper.Desktop.ViewModels;
using ReactiveUI;

namespace PassKeeper.Desktop.Views
{
    public class CadetsView : ReactiveUserControl<CadetsViewModel>
    {
        public CadetsView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.WhenActivated(disposables => { });
            AvaloniaXamlLoader.Load(this);
        }
    }
}