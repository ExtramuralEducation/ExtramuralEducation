using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExtramuralEducation.Core;
using ExtramuralEducation.ViewModels;

namespace ExtramuralEducation.WebSite.Controllers
{
    public partial class MenuController : Controller
    {
        [ChildActionOnly]
        public virtual ActionResult MainMenu()
        {
            var menuItems = new List<MenuItem>();

            //Admin menu
            var adminSubMenu = new List<MenuItem>();
            adminSubMenu.Add(new MenuItem() { Action = "Index", Controller = "AdminInstitution", Text = TranslateHelper.Translate("Institutions") });
            adminSubMenu.Add(new MenuItem() { Action = "Index", Controller = "AdminUser", Text = TranslateHelper.Translate("Users") });
            menuItems.Add(new MenuItem() { Text = TranslateHelper.Translate("Admin"), SubItems = adminSubMenu});
            return View(MVC.Menu.Views.MainMenu, menuItems);
        }

    }
}
