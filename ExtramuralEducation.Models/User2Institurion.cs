using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ExtramuralEducation.Models
{
    public class User2Institurion:IEntity
    {
        public long Id { get; set; }

        [ForeignKey("Institution")]
        public long InstituteId { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }
    
        public Institution Institution { get; set; }

        public User User { get; set; }
    }
}
