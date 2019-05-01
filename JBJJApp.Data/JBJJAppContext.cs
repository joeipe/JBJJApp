using JBJJApp.Domain;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBJJApp.Data
{
    public class JBJJAppContext : DbContext
    {
        public JBJJAppContext()
            : base("name=JBJJDBConnectionString")
        {

        }
        public DbSet<ClassType> ClassTypes { get; set; }
        public DbSet<TimeTable> TimeTables { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Outcome> Outcomes { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<SparringDetails> SparringDetails { get; set; }

        public override int SaveChanges()
        {
            var now = DateTime.Now;

            foreach (var changedEntity in ChangeTracker.Entries())
            {
                if (changedEntity.Entity is IEntityDate entity)
                {
                    switch (changedEntity.State)
                    {
                        case EntityState.Added:
                            entity.CreatedDate = now;
                            entity.UpdatedDate = now;
                            break;

                        case EntityState.Modified:
                            Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                            entity.UpdatedDate = now;
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema("Schedule");//for bounded context
            modelBuilder.Types<IStateObject>().Configure(c => c.Ignore(p => p.State));
            base.OnModelCreating(modelBuilder); 
        }
    }
}
