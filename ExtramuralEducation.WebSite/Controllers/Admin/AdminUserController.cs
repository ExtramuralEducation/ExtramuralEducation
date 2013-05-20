using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ExtramuralEducation.Managers.Contracts;
using ExtramuralEducation.Mappers;
using ExtramuralEducation.ViewModels;

namespace ExtramuralEducation.WebSite.Controllers.Admin
{
    public partial class AdminUserController : Controller
    {
        private readonly IUserManager _userManager;

        public AdminUserController(IUserManager userManager)
        {
            this._userManager = userManager;
        }

        public virtual ActionResult Index()
        {
            var viewModel = this._userManager.GetAllUsers().Select(UserMapper.ToViewModel).ToList();

            foreach (var user in viewModel)
            {
                user.Roles = Roles.GetRolesForUser(user.Username);
            }

            return View(viewModel);
        }

        #region AdduserMethods

        [HttpGet]
        public virtual ActionResult AddUser()
        {
            var viewModel = new UserViewModel();
            viewModel.RolesListItems = Roles.GetAllRoles().Select(x => new SelectListItem() { Text = x, Value = x });

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
            return PartialView(MVC.AdminUser.Views.Partial.DeleteUser,userId);
        }

        [HttpPost]
        public virtual ActionResult DeleteUser(Guid Id)
        {
            var isDeleted = WebSecurity.DeleteUserById(Id);

            return this.Json(new { success = isDeleted });

        }

        private List<string> ModelErrorString()
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
