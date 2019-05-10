namespace Schedule.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTimeTableListView : DbMigration
    {
        public override void Up()
        {
            Sql
                (
                @"CREATE VIEW Schedule.TimeTableList AS
                    SELECT T.Id, 
                    (CASE T.DayofWeek WHEN 1 THEN 'Monday' WHEN 2 THEN 'Tuesday' WHEN 3 THEN 'Wednesday' WHEN 4 THEN 'Thursday' WHEN 5 THEN 'Friday' WHEN 6 THEN 'Saturday' WHEN 7 THEN 'Sunday' END) DayofWeek,
                    T.StartTimeHr, T.StartTimeMin, T.EndTimeHr, T.EndTimeMin, C.Name ClassType
                    FROM Schedule.TimeTables T
                    inner join Schedule.ClassTypes C on C.Id=T.ClassTypeId"
                );
        }
        
        public override void Down()
        {
            Sql("DROP VIEW Schedule.TimeTableList");
        }
    }
}
