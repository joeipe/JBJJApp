using DayAtDojo.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayAtDojo.Data
{
    public class ReferenceStudentContext : DbContext
    {
        public ReferenceStudentContext()
            : base("name=JBJJDBConnectionString")
        {

        }

        public DbSet<PersonSparringPartner> PersonSparringPartners { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Student");
            modelBuilder.Entity<PersonSparringPartner>().ToTable("PersonList");
            base.OnModelCreating(modelBuilder);
        }
    }
}
