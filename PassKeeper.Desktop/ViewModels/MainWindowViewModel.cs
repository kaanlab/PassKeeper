using Avalonia.Controls;
using Avalonia.ReactiveUI;
using PassKeeper.CoreLib.Services;
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

        public MainWindowViewModel(StorageService storageService)
        {
            Tabs.Add(new CadetsViewModel(storageService.GetCadets()));
            Tabs.Add(new PasswordsViewModel());              
        }
    }
}
