namespace Schedule.Data.Migrations
{
    using Schedule.Domain;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Schedule.Data.ScheduleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Schedule.Data.ScheduleContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            {
                IList<ClassType> defaultClassTypes = new List<ClassType>();

                defaultClassTypes.Add(new ClassType() { Name = "BJJ Gi All Levels" });
                defaultClassTypes.Add(new ClassType() { Name = "BJJ Gi Fundamenals" });
                defaultClassTypes.Add(new ClassType() { Name = "BJJ No Gi All Levels" });
                defaultClassTypes.Add(new ClassType() { Name = "BJJ Gi Biginners" });
                defaultClassTypes.Add(new ClassType() { Name = "BJJ Advanced Class" });
                defaultClassTypes.Add(new ClassType() { Name = "BJJ Competition Class" });

                context.ClassTypes.AddRange(defaultClassTypes);
            }

            {
                IList<TimeTable> defaultTimeTables = new List<TimeTable>();

                defaultTimeTables.Add(new TimeTable() { DayofWeek = DayofWeek.Monday, StartTimeHr = 6, StartTimeMin = 45, EndTimeHr = 7, EndTimeMin = 45, ClassTypeId = 1 });
                defaultTimeTables.Add(new TimeTable() { DayofWeek = DayofWeek.Monday, StartTimeHr = 18, StartTimeMin = 30, EndTimeHr = 19, EndTimeMin = 30, ClassTypeId = 4 });
                defaultTimeTables.Add(new TimeTable() { DayofWeek = DayofWeek.Monday, StartTimeHr = 19, StartTimeMin = 30, EndTimeHr = 20, EndTimeMin = 30, ClassTypeId = 5 });
                defaultTimeTables.Add(new TimeTable() { DayofWeek = DayofWeek.Tuesday, StartTimeHr = 18, StartTimeMin = 30, EndTimeHr = 19, EndTimeMin = 30, ClassTypeId = 2 });
                defaultTimeTables.Add(new TimeTable() { DayofWeek = DayofWeek.Tuesday, StartTimeHr = 19, StartTimeMin = 30, EndTimeHr = 20, EndTimeMin = 30, ClassTypeId = 6 });
                defaultTimeTables.Add(new TimeTable() { DayofWeek = DayofWeek.Wednesday, StartTimeHr = 18, StartTimeMin = 30, EndTimeHr = 19, EndTimeMin = 30, ClassTypeId = 4 });
                defaultTimeTables.Add(new TimeTable() { DayofWeek = DayofWeek.Wednesday, StartTimeHr = 19, StartTimeMin = 30, EndTimeHr = 20, EndTimeMin = 30, ClassTypeId = 1 });
                defaultTimeTables.Add(new TimeTable() { DayofWeek = DayofWeek.Thursday, StartTimeHr = 18, StartTimeMin = 30, EndTimeHr = 19, EndTimeMin = 30, ClassTypeId = 1 });
                defaultTimeTables.Add(new TimeTable() { DayofWeek = DayofWeek.Thursday, StartTimeHr = 19, StartTimeMin = 30, EndTimeHr = 20, EndTimeMin = 30, ClassTypeId = 3 });

                context.TimeTables.AddRange(defaultTimeTables);
            }

            base.Seed(context);
        }
    }
}
