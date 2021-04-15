using PassKeeper.CoreLib.Models;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PassKeeper.Desktop.ViewModels
{
    public class CadetsViewModel : ViewModelBaseTab
    {
        private string _searchTerm;
        public string SearchTerm
        {
            get => _searchTerm;
            set => this.RaiseAndSetIfChanged(ref _searchTerm, value);
        }

        private readonly ObservableAsPropertyHelper<IEnumerable<Cadet>> _searchResults;
        public IEnumerable<Cadet> SearchResults => _searchResults.Value;

        public ObservableCollection<Cadet> Cadets { get; set; }

        public CadetsViewModel(IEnumerable<Cadet> cadets)
        {
            Header = "Кадеты";

            Cadets = new ObservableCollection<Cadet>(cadets);

            _searchResults = this
                .WhenAnyValue(x => x.SearchTerm)
                .Throttle(TimeSpan.FromMilliseconds(800))
                .Select(term => term?.Trim())
                .DistinctUntilChanged()
                .Where(term => !string.IsNullOrWhiteSpace(term))
                .SelectMany(SearchCadets)
                .ObserveOn(RxApp.MainThreadScheduler)
                .ToProperty(this, x => x.SearchResults);

            _searchResults.ThrownExceptions.Subscribe(error => { new Exception("Some exeption");});
        }

        private async Task<IEnumerable<Cadet>> SearchCadets(string term, CancellationToken token)
        {
            var result = await Task.Run(() => Cadets.Where(c => (c.LastName ?? "").ToLower().Contains(term) || (c.FirstName ?? "").ToLower().Contains(term)));
            if (result.Any())
                return result;

            return new[] { new Cadet() };
        }
    }
}
