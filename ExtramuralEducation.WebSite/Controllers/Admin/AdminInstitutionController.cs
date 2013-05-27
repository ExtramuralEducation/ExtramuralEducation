using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExtramuralEducation.Managers.Contracts;
using ExtramuralEducation.Mappers;
using ExtramuralEducation.Models.Constants;
using ExtramuralEducation.ViewModels;

namespace ExtramuralEducation.WebSite.Controllers.Admin
{
    [Authorize(Roles = RolesNames.Administrator)]
    public partial class AdminInstitutionController : BaseController
    {
        private readonly IInstitutionManager _institutionManager;

        public AdminInstitutionController(IInstitutionManager institutionManager)
        {
            this._institutionManager = institutionManager;
        }

        public virtual ActionResult Index()
        {
            var institutions = this._institutionManager.GetAll().Select(InstitutionMapper.ToViewModelExp);

            return View(institutions);
        }

        [HttpGet]
        public virtual ActionResult Add()
        {
            return PartialView(MVC.AdminInstitution.Views.Partial.Add);
        }

        [HttpPost]
        public virtual ActionResult Add(InstitutionViewModel viewModel)
        {
            if (ModelState.IsValid && Request.IsAjaxRequest())
            {
                var model = viewModel.ToModel();
                var success = this._institutionManager.AddInstitute(model);

                return this.Json(new {success});
            }

            return this.Json(new {success = false});
        }
    }
}
