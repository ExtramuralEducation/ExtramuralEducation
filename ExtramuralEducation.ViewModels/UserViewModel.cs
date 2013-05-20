using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using ExtramuralEducation.Core.CustomAttributes;
using ExtramuralEducation.Models;

namespace ExtramuralEducation.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            this.Roles = new List<string>();
        }

        public  Guid UserId { get; set; }

        [Required]
        public String Username { get; set; }

        [Required]
        [Email(ErrorMessage = "Invalid email address")]
        public String Email { get; set; }

        [Required, DataType(DataType.Password)]
        public String Password { get; set; }

        public String FirstName { get; set; }
        public String LastName { get; set; }

        [DataType(DataType.MultilineText)]
        public String Comment { get; set; }

        public Boolean IsApproved { get; set; }
        public int PasswordFailuresSinceLastSuccess { get; set; }
        public DateTime? LastPasswordFailureDate { get; set; }
        public DateTime? LastActivityDate { get; set; }
        public DateTime? LastLockoutDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public String ConfirmationToken { get; set; }
        public DateTime? CreateDate { get; set; }
        public Boolean IsLockedOut { get; set; }
        public DateTime? LastPasswordChangedDate { get; set; }
        public String PasswordVerificationToken { get; set; }
        public DateTime? PasswordVerificationTokenExpirationDate { get; set; }

        public IEnumerable<string> Roles { get; set; }

        public string Role { get; set; }

        public IEnumerable<SelectListItem> RolesListItems { get; set; }
    }
}
