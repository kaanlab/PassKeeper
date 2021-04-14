using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using PassKeeper.Desktop.ViewModels;
using ReactiveUI;

namespace PassKeeper.Desktop.Views
{
    public class PasswordsView : UserControl
    {
        public PasswordsView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
