using Avalonia.ReactiveUI;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Input;

namespace PassKeeper.Desktop.ViewModels
{

    public class MainWindowViewModel : ViewModelBase, IScreen
    {
        private readonly ReactiveCommand<Unit, Unit> _cadets;
        private readonly ReactiveCommand<Unit, Unit> _passwords;
        private RoutingState _router = new RoutingState();


        public MainWindowViewModel()
        {
            // If the authorization page is currently shown, then
            // we disable the "Open authorization view" button.
            var canShowCadets = this
                .WhenAnyObservable(x => x.Router.CurrentViewModel)
                .Select(current => !(current is CadetsViewModel));

            _cadets = ReactiveCommand.Create(
                () => { Router.Navigate.Execute(new CadetsViewModel()); },
                canShowCadets);

            // If the search screen is currently shown, then we
            // disable the "Open search view" button.
            var canShowPasswords = this
                .WhenAnyObservable(x => x.Router.CurrentViewModel)
                .Select(current => !(current is PasswordsViewModel));

            _passwords = ReactiveCommand.Create(
                () => { Router.Navigate.Execute(new PasswordsViewModel()); },
                canShowPasswords);
        }

        public RoutingState Router
        {
            get => _router;
            set => this.RaiseAndSetIfChanged(ref _router, value);
        }

        public ICommand Cadets => _cadets;

        public ICommand Passwords => _passwords;

    }
}
