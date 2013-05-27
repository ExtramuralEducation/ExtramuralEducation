using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExtramuralEducation.Models.Constants;

namespace ExtramuralEducation.WebSite.Controllers
{
    public class BaseController : Controller
    {
        protected Guid CurrentUserId 
        {
            get { return (Guid)this.Session[SessionKeys.UserId]; }
        }

        protected string CurrentUsername
        {
            get { return User.Identity.Name; }
        }

        protected long? CurrentInstitutionId 
        {
            get { return (long?) this.Session[SessionKeys.InstituteId]; }
        }



        protected List<string> ModelErrorString()
        {
            var errors = new List<string>();

            foreach (var er in this.ModelState)
            {
                errors.AddRange(er.Value.Errors.Select(x => x.ErrorMessage));
            }

            return errors;
        }
    }
}
