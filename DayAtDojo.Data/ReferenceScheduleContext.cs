using DayAtDojo.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayAtDojo.Data
{
    public class ReferenceScheduleContext : DbContext
    {
        public ReferenceScheduleContext()
            : base("name=JBJJDBConnectionString")
        {

        }

        public DbSet<TimeTableClassAttended> TimeTableClassAttended { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Schedule");
            modelBuilder.Entity<TimeTableClassAttended>().ToTable("TimeTableList");
            base.OnModelCreating(modelBuilder);
        }
    }
}
