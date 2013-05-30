using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ExtramuralEducation.Models
{
    public class Teacher : IEntity
    {
        [Key]
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public User2Institurion User2Institurion { get; set; }
    }
}
