using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassKeeper.Desktop.ViewModels
{
    public class PasswordsViewModel : ViewModelBaseTab 
    {
        public int Count { get; set; }
        public int DigitsInPass { get; set; }
        public int CharsInPass { get; set; }
        public string PathToAdjectivesDictionary { get; set; }
        public string PathToNounDictionary { get; set; }



        public PasswordsViewModel()
        {
            Header = "Пароли";
        }
    }
}
