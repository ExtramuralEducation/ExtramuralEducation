using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace ExtramuralEducation.ViewModels
{
    public class UserInstitutionsViewModel
    {
        public UserInstitutionsViewModel()
        {
            this.InstitutionsList = new List<SelectListItem>();
            this.Institutions = new List<InstitutionViewModel>();
        }

        public string Username { get; set; }

        public IEnumerable<SelectListItem> InstitutionsList { get; set; }

        public IEnumerable<InstitutionViewModel> Institutions { get; set; } 
    }
}
