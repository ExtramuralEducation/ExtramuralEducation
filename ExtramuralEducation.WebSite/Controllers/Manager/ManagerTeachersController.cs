﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExtramuralEducation.Models.Constants;

namespace ExtramuralEducation.WebSite.Controllers.Manager
{
    [Authorize(Roles = RolesNames.Manager)]
    public class ManagerTeachersController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}
