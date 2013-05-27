using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ExtramuralEducation.Models.Constants;

namespace ExtramuralEducation.WebSite.Controllers
{
    public partial class HomeController : Controller
    {
        public virtual ActionResult Index()
        {
            WebSecurity.Register("admin", "123", "iamspena@gmail.com", true, "Andrey", "LastName");
            Roles.AddUserToRole("admin", RolesNames.Administrator);
            Roles.AddUserToRole("admin", RolesNames.Manager);

            return View();
        }

    }
}
