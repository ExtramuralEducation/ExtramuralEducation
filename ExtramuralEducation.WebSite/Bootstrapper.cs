using System.Data.Entity;
using System.Web.Mvc;
using ExtramuralEducation.Managers;
using ExtramuralEducation.Managers.Contracts;
using ExtramuralEducation.Models;
using ExtramuralEducation.Repository.Contracts;
using ExtramuralEducation.Repository;
using Microsoft.Practices.Unity;
using Unity.Mvc3;

namespace ExtramuralEducation.WebSite
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<DbContext, ExtramuralEducation.DataContext.DataContext>();

            //Repositories
            container.RegisterType<IRepository<Institution>, Repository<Institution>>();
            container.RegisterType<IRepository<User>, Repository<User>>();  
       
            //Managers
            container.RegisterType<IInstitutionManager, InstitutionManager>();
            container.RegisterType<IUserManager, UserManager>();

            return container;
        }
    }
}