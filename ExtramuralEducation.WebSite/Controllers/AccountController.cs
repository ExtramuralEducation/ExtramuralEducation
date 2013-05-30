using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ExtramuralEducation.Managers.Contracts;
using ExtramuralEducation.Models.Constants;
using ExtramuralEducation.ViewModels;

namespace ExtramuralEducation.WebSite.Controllers
{
    public partial class AccountController : BaseController
    {
        private readonly IInstitutionManager _institutionManager;

        public AccountController(IInstitutionManager institutionManager)
        {
            this._institutionManager = institutionManager;
        }

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
            var user = WebSecurity.GetUser(userName);
            this.CurrentUserId = (Guid)user.ProviderUserKey;
            var institute = this._institutionManager.GetInstitutesForUser((Guid) user.ProviderUserKey).FirstOrDefault();

            if (institute != null)
            {
                this.CurrentInstitutionId = institute.Id;
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
