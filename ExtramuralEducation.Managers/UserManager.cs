using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExtramuralEducation.Managers.Contracts;
using ExtramuralEducation.Models;
using ExtramuralEducation.Repository.Contracts;

namespace ExtramuralEducation.Managers
{
    public class UserManager:IUserManager
    {
        private readonly IRepository<User> _userRepository;

        public UserManager(IRepository<User> userRepository)
        {
            this._userRepository = userRepository;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return this._userRepository.GetAll();
        }
    }
}
