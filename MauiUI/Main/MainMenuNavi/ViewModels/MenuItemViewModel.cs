using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiUI.Main.MainMenuNavi.ViewModels
{
    public class MenuItemViewModel
    {
        // Title to display on the button
        public string Title { get; set; }

        public ICommand Command { get; set; }

    }
}

