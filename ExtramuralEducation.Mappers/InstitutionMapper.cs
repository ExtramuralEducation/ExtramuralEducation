using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ExtramuralEducation.Models;
using ExtramuralEducation.ViewModels;
using Omu.ValueInjecter;

namespace ExtramuralEducation.Mappers
{
    public static  class InstitutionMapper
    {
        public static Func<Institution, InstitutionViewModel> ToViewModelExp = institution =>
                                                                        new InstitutionViewModel()
                                                                            {
                                                                                Id = institution.Id, 
                                                                                Name = institution.Name
                                                                            };

        public static Institution ToModel(this InstitutionViewModel viewModel)
        {
            var model = new Institution();
            model.InjectFrom(viewModel);

            return model;
        }
    }
}
