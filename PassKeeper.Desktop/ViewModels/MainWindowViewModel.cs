using Avalonia.Controls;
using Avalonia.ReactiveUI;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Input;

namespace PassKeeper.Desktop.ViewModels
{

    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<ViewModelBaseTab> Tabs { get; } = new();

        public MainWindowViewModel()
        {
            Tabs.Add(new CadetsViewModel());
            Tabs.Add(new PasswordsViewModel());              
        }
    }
}
