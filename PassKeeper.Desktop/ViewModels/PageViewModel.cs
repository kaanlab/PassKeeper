using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassKeeper.Desktop.ViewModels
{
    public class PageViewModel : ViewModelBase
    {
        public TabItemViewModel[] Tabs { get; set; }
        
    }

    public class TabItemViewModel
    {
        public string Header { get; set; }
        public ViewModelBase Content { get; set; }
    }
}
