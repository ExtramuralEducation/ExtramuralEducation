using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using ExtramuralEducation.Models;

namespace ExtramuralEducation.DataContext
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("ExtramuralEducationDB")
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Institution> Institutions { get; set; }

        public DbSet<User2Institurion> User2Institurions { get; set; }
    }
}
