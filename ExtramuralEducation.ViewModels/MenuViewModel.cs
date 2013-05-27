using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtramuralEducation.ViewModels
{
    public class MenuViewModel
    {
        public MenuViewModel()
        {
            this.MenuItems = new List<MenuItem>();
        }

        public string UserName { get; set; }

        public List<MenuItem> MenuItems { get; set; }
    }
}
