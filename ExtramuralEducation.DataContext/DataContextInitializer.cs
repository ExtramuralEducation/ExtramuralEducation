using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web.Security;
using ExtramuralEducation.Models;
using ExtramuralEducation.Models.Constants;

namespace ExtramuralEducation.DataContext
{
    public class DataContextInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            Roles.CreateRole(RolesNames.Administrator);
            Roles.CreateRole(RolesNames.Manager);
            Roles.CreateRole(RolesNames.Pupil);
            Roles.CreateRole(RolesNames.Teacher);
            base.Seed(context);
        }
    }
}
