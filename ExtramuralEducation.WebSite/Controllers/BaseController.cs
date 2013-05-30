using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExtramuralEducation.Models.Constants;

namespace ExtramuralEducation.WebSite.Controllers
{
    public partial class BaseController : Controller
    {
        protected Guid CurrentUserId 
        {
            get { return (Guid)this.HttpContext.Cache[CacheKeys.UserId]; }
            set { this.HttpContext.Cache[CacheKeys.UserId] = value; }
        }

        protected string CurrentUsername
        {
            get { return User.Identity.Name; }
        }

        protected long? CurrentInstitutionId 
        {
            get { return (long?) this.HttpContext.Cache[CacheKeys.InstituteId]; }
            set { this.HttpContext.Cache[CacheKeys.InstituteId] = value; }
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
