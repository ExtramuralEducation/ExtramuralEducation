using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExtramuralEducation.Models;

namespace ExtramuralEducation.Managers.Contracts
{
    public interface IUserManager
    {
        IEnumerable<User> GetAllUsers();
    }
}
