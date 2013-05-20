using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtramuralEducation.Models
{
    public class Institution : IEntity
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }
}
