using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ExtramuralEducation.ViewModels
{
    public class LogOnViewModel
    {       
        [Required]
        public virtual String Username { get; set; }

        [Required, DataType(DataType.Password)]
        public virtual String Password { get; set; }
    }
}
