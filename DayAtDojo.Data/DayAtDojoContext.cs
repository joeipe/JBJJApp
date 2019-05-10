using DayAtDojo.Domain;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayAtDojo.Data
{
    public class DayAtDojoContext : DbContext
    {
        public DayAtDojoContext()
            : base("name=JBJJDBConnectionString")
        {

        }

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
            modelBuilder.HasDefaultSchema("DayAtDojo");
            modelBuilder.Types<IStateObject>().Configure(c => c.Ignore(p => p.State));
            modelBuilder.Ignore<TimeTableClassAttended>();
            modelBuilder.Ignore<PersonSparringPartner>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
