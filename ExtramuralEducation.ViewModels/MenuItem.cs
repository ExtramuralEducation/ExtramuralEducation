using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtramuralEducation.ViewModels
{
    public class MenuItem
    {
        public MenuItem()
        {
            this.SubItems = new List<MenuItem>();
        }

        public string Controller { get; set; }

        public string Action { get; set; }

        public string Text { get; set; }

        public bool Selected { get; set; }

        public List<MenuItem> SubItems { get; set; }
    }
}
