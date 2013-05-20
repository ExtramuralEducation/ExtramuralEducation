using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using ExtramuralEducation.Models;
using ExtramuralEducation.ViewModels;
using Omu.ValueInjecter;

namespace ExtramuralEducation.Mappers
{
    public static class UserMapper
    {
        public static Func<User, UserViewModel> ToViewModel = user =>
            {
                var viewModel = new UserViewModel();
                viewModel.InjectFrom(user);

                return viewModel;
            };

        public static User ToModel(this UserViewModel viewModel)
        {
            var model = new User();
            model.InjectFrom(viewModel);

            return model;
        }

        public static UserViewModel UserViewModel(this User model)
        {
            var viewModel = new UserViewModel();
            viewModel.InjectFrom(model);

            return viewModel;
        }
    }
}
