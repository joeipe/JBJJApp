namespace DayAtDojo.Data.Migrations
{
    using DayAtDojo.Domain;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DayAtDojo.Data.DayAtDojoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DayAtDojo.Data.DayAtDojoContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            {
                IList<Outcome> defaultOutcomes = new List<Outcome>();

                defaultOutcomes.Add(new Outcome() { Name = "Win" });
                defaultOutcomes.Add(new Outcome() { Name = "Loose" });
                defaultOutcomes.Add(new Outcome() { Name = "Advantage" });
                defaultOutcomes.Add(new Outcome() { Name = "Disadvantage" });
                defaultOutcomes.Add(new Outcome() { Name = "Neutral" });

                context.Outcomes.AddRange(defaultOutcomes);
            }

            {
                IList<Attendance> defaultAttendances = new List<Attendance>();

                defaultAttendances.Add(new Attendance() { TimeTableId = 1, AttendedOn = DateTime.Now, TechniqueOfTheDay = "Rear naked choke" });

                context.Attendance.AddRange(defaultAttendances);
            }

            {
                IList<SparringDetails> defaultSparringDetailss = new List<SparringDetails>();

                defaultSparringDetailss.Add(new SparringDetails() { AttendanceId = 1, PersonId = 1, OutcomeId = 2, TechniqueUsed = "Knee on belly" });
                defaultSparringDetailss.Add(new SparringDetails() { AttendanceId = 1, PersonId = 2, OutcomeId = 4, TechniqueUsed = "Passing the guarg" });
                defaultSparringDetailss.Add(new SparringDetails() { AttendanceId = 1, PersonId = 3, OutcomeId = 5, TechniqueUsed = "Arm bar from Guard" });

                context.SparringDetails.AddRange(defaultSparringDetailss);
            }
        }
    }
}
