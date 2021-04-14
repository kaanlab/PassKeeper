using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassKeeper.Desktop.ViewModels
{
    public class CadetsViewModel : ViewModelBaseTab
    {
        public string Name { get; set; } = "new name sample";

        public CadetsViewModel()
        {
            Header = "Кадеты";
        }


    }
}
