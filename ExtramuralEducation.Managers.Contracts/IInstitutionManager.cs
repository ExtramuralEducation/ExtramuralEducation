using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExtramuralEducation.Models;

namespace ExtramuralEducation.Managers.Contracts
{
    public interface IInstitutionManager
    {
        Institution GetById(long Id);

        IEnumerable<Institution> GetAll();

        bool AddInstitute(Institution entitty);
    }
}
