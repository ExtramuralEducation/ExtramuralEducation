﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExtramuralEducation.WebSite.Controllers
{
    public partial class TeacherController : Controller
    {
        public virtual ActionResult Index()
        {
            return View();
        }

    }
}
