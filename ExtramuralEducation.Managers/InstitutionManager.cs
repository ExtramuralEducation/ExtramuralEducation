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
        private readonly IRepository<User2Institurion> _user2InstitutionRepository;
        private readonly IUserManager _userManager;

        public InstitutionManager(IRepository<Institution> institutionRepository, 
            IRepository<User2Institurion> user2InstitutionRepository,
            IUserManager userManager)
        {
            this._institutionRepository = institutionRepository;
            this._user2InstitutionRepository = user2InstitutionRepository;
            this._userManager = userManager;
        }

        public Institution GetById(long Id)
        {
            return this._institutionRepository.Get(Id);
        }

        public IEnumerable<Institution> GetAll()
        {
            return this._institutionRepository.GetAll();
        }


        public IEnumerable<Institution> GetInstitutesNamesForUser(Guid userId)
        {
            return _user2InstitutionRepository
                .GetAll(x => x.Institution, x => x.User)
                .Where(x => x.User.UserId == userId)
                .Select(x => x.Institution);
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

        public void AddUserToInstitutes(IEnumerable<long> institutesIds, Guid userId)
        {
            if (this._userManager.UserExist(userId))
            {
                var instutesDb = this._user2InstitutionRepository
                                     .GetAll(x => x.User, x => x.Institution)
                                     .Where(x => x.User.UserId == userId);

                foreach (var instituteId in institutesIds)
                {
                    if (this._institutionRepository.IsEntityExist(instituteId) &&
                        !instutesDb.Any(x => x.Institution.Id == instituteId))
                    {
                        var entity = new User2Institurion();
                        entity.UserId = userId;
                        entity.InstituteId = instituteId;
                        this._user2InstitutionRepository.Add(entity);            
                    }
                }

                foreach (var institute in instutesDb)
                {
                    if (!institutesIds.Any(x => x == institute.InstituteId))
                    {
                        this._user2InstitutionRepository.Delete(institute.Id);
                    }
                }

                this._user2InstitutionRepository.Commit();
            }
        }
    }
}
