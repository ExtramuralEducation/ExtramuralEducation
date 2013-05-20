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
            //WebSecurity.Register("manager", "123456", "iamspenar@gmail.com", true, "Andrey", "LastName");
            //WebSecurity.Register("admin", "123456", "iamspena@gmail.com", true, "Andrey", "LastName");
            //WebSecurity.Register("teacher", "123456", "iamspnar@gmail.com", true, "Andrey", "LastName");
            //WebSecurity.Register("pupil", "123456", "iampenar@gmail.com", true, "Andrey", "LastName");

            //Roles.AddUserToRole("manager", RolesNames.Manager);
            //Roles.AddUserToRole("admin", RolesNames.Administrator);
            //Roles.AddUserToRole("teacher", RolesNames.Teacher);
            //Roles.AddUserToRole("pupil", RolesNames.Pupil);

            return View();
        }

    }
}
