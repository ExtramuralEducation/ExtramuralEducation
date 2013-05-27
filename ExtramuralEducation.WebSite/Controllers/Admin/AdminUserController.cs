using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ExtramuralEducation.Managers.Contracts;
using ExtramuralEducation.Mappers;
using ExtramuralEducation.Models.Constants;
using ExtramuralEducation.ViewModels;

namespace ExtramuralEducation.WebSite.Controllers.Admin
{
    [Authorize(Roles = RolesNames.Administrator)]
    public partial class AdminUserController : BaseController
    {
        private readonly IUserManager _userManager;

        private readonly IInstitutionManager _institutionManager;

        public AdminUserController(IUserManager userManager, IInstitutionManager institutionManager)
        {
            this._userManager = userManager;
            this._institutionManager = institutionManager;
        }

        public virtual ActionResult Index()
        {
            var viewModel = this._userManager.GetAllUsers().Select(UserMapper.ToViewModel).ToList();

            foreach (var user in viewModel)
            {
                user.Roles = Roles.GetRolesForUser(user.Username);
            }

            foreach (var user in viewModel)
            {
                user.Institutions = this._institutionManager.GetInstitutesNamesForUser(user.UserId);
            }

            return View(viewModel);
        }

        #region AdduserMethods

        [HttpGet]
        public virtual ActionResult AddUser()
        {
            var viewModel = new UserViewModel();
            viewModel.RolesListItems = Roles.GetAllRoles().Select(x => new SelectListItem() { Text = x, Value = x });
            viewModel.InstituteItems =
                this._institutionManager.GetAll().Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() });

            return PartialView(MVC.AdminUser.Views.Partial.UserFields, viewModel);
        }

        [HttpPost]
        public virtual ActionResult AddUser(UserViewModel viewModel)
        {
            if (ModelState.IsValid && Request.IsAjaxRequest())
            {
                var status = WebSecurity.Register(viewModel.Username, viewModel.Password, viewModel.Email, true, viewModel.FirstName,
                                     viewModel.LastName);


                if (status == MembershipCreateStatus.Success)
                {
                    if (Roles.RoleExists(viewModel.Role))
                    {
                        Roles.AddUserToRole(viewModel.Username, viewModel.Role);
                    }

                    var user = WebSecurity.GetUser(viewModel.Username);
                    this._institutionManager.AddUserToInstitutes(viewModel.Institutions.Select(x => x.Id), (Guid)user.ProviderUserKey);

                    return this.Json(new { success = true });
                }
            }
            return this.Json(new { success = false, errors = this.ModelErrorString() });
        }
        #endregion

        [HttpGet]
        public virtual ActionResult DeleteUser(string userName)
        {
            var userId = WebSecurity.GetUserId(userName);
            return PartialView(MVC.AdminUser.Views.Partial.DeleteUser, userId);
        }

        [HttpPost]
        public virtual ActionResult DeleteUser(Guid Id)
        {
            var isDeleted = WebSecurity.DeleteUserById(Id);

            return this.Json(new { success = isDeleted });
        }
    }
}
