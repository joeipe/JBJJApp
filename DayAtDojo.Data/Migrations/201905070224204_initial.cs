namespace DayAtDojo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "DayAtDojo.Attendances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TimeTableId = c.Int(nullable: false),
                        AttendedOn = c.DateTime(nullable: false),
                        TechniqueOfTheDay = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "DayAtDojo.SparringDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AttendanceId = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                        OutcomeId = c.Int(nullable: false),
                        TechniqueUsed = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("DayAtDojo.Attendances", t => t.AttendanceId, cascadeDelete: true)
                .ForeignKey("DayAtDojo.Outcomes", t => t.OutcomeId, cascadeDelete: true)
                .Index(t => t.AttendanceId)
                .Index(t => t.OutcomeId);
            
            CreateTable(
                "DayAtDojo.Outcomes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("DayAtDojo.SparringDetails", "OutcomeId", "DayAtDojo.Outcomes");
            DropForeignKey("DayAtDojo.SparringDetails", "AttendanceId", "DayAtDojo.Attendances");
            DropIndex("DayAtDojo.SparringDetails", new[] { "OutcomeId" });
            DropIndex("DayAtDojo.SparringDetails", new[] { "AttendanceId" });
            DropTable("DayAtDojo.Outcomes");
            DropTable("DayAtDojo.SparringDetails");
            DropTable("DayAtDojo.Attendances");
        }
    }
}
