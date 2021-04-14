using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using PassKeeper.Desktop.ViewModels;
using ReactiveUI;

namespace PassKeeper.Desktop.Views
{
    public class CadetsView : UserControl
    {
        public CadetsView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
