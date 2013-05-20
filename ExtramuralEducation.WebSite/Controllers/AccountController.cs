using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ExtramuralEducation.Models.Constants;
using ExtramuralEducation.ViewModels;

namespace ExtramuralEducation.WebSite.Controllers
{
    public partial class AccountController : Controller
    {
        #region LogOn
        [HttpGet]
        public virtual ActionResult LogOn()
        {
            return View("Partial/LogOn");
        }

        [HttpPost]
        public virtual ActionResult LogOn(LogOnViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
               var loginSuccess = WebSecurity.Login(viewModel.Username, viewModel.Password, true);

                if (loginSuccess)
                {
                    return RedirectByRole(viewModel.Username);
                }
            }

            return View("Partial/LogOn", viewModel);
        }

        public virtual ActionResult RedirectByRole(string userName)
        {
            var roles = Roles.GetRolesForUser(userName);

            if (roles.Any(x => x == RolesNames.Manager))
            {
                return RedirectToAction("Index", "Manager");
            }

            if (roles.Any(x => x == RolesNames.Teacher))
            {
                return RedirectToAction("Index", "Teacher");
            }

            if (roles.Any(x => x == RolesNames.Pupil))
            {
                return RedirectToAction("Index", "Pupil");
            }

            if (roles.Any(x => x == RolesNames.Administrator))
            {
                return RedirectToAction("Index", "Admin");
            }

            return RedirectToAction("Index", "Home");
        }
        #endregion

        [HttpGet]
        public virtual ActionResult Registration()
        {
            return View();
        }

    }
}
