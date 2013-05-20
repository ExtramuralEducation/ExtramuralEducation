using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExtramuralEducation.Managers.Contracts;
using ExtramuralEducation.Models;
using ExtramuralEducation.Repository.Contracts;

namespace ExtramuralEducation.Managers
{
    public class InstitutionManager : IInstitutionManager
    {
        private readonly IRepository<Institution> _institutionRepository;

        public InstitutionManager(IRepository<Institution> institutionRepository)
        {
            this._institutionRepository = institutionRepository;
        }

        public Institution GetById(long Id)
        {
            return this._institutionRepository.Get(Id);
        }

        public IEnumerable<Institution> GetAll()
        {
            return this._institutionRepository.GetAll();
        }

        public bool AddInstitute(Institution entitty)
        {
            try
            {
                this._institutionRepository.Add(entitty);
                this._institutionRepository.Commit();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
