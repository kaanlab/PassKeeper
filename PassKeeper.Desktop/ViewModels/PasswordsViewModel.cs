using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassKeeper.Desktop.ViewModels
{
    public class PasswordsViewModel : ViewModelBase, IRoutableViewModel
    {
        public IScreen HostScreen { get; }
        public string UrlPathSegment => "/passwords";

        public int Count { get; set; }
        public int DigitsInPass { get; set; }
        public int CharsInPass { get; set; }
        public string PathToAdjectivesDictionary { get; set; }
        public string PathToNounDictionary { get; set; }



        public PasswordsViewModel(IScreen? screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        }
    }
}
