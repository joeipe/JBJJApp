namespace JBJJApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TimeTableId = c.Int(nullable: false),
                        AttendedOn = c.DateTime(nullable: false),
                        TechniqueOfTheDay = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TimeTables", t => t.TimeTableId, cascadeDelete: true)
                .Index(t => t.TimeTableId);
            
            CreateTable(
                "dbo.SparringDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AttendanceId = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                        OutcomeId = c.Int(nullable: false),
                        TechniqueUsed = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Attendances", t => t.AttendanceId, cascadeDelete: true)
                .ForeignKey("dbo.Outcomes", t => t.OutcomeId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.AttendanceId)
                .Index(t => t.PersonId)
                .Index(t => t.OutcomeId);
            
            CreateTable(
                "dbo.Outcomes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        GradeId = c.Int(nullable: false),
                        Stripe = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Grades", t => t.GradeId, cascadeDelete: true)
                .Index(t => t.GradeId);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TimeTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DayofWeek = c.Int(nullable: false),
                        StartTimeHr = c.Int(nullable: false),
                        StartTimeMin = c.Int(nullable: false),
                        EndTimeHr = c.Int(nullable: false),
                        EndTimeMin = c.Int(nullable: false),
                        ClassTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClassTypes", t => t.ClassTypeId, cascadeDelete: true)
                .Index(t => t.ClassTypeId);
            
            CreateTable(
                "dbo.ClassTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TimeTables", "ClassTypeId", "dbo.ClassTypes");
            DropForeignKey("dbo.Attendances", "TimeTableId", "dbo.TimeTables");
            DropForeignKey("dbo.SparringDetails", "PersonId", "dbo.People");
            DropForeignKey("dbo.People", "GradeId", "dbo.Grades");
            DropForeignKey("dbo.SparringDetails", "OutcomeId", "dbo.Outcomes");
            DropForeignKey("dbo.SparringDetails", "AttendanceId", "dbo.Attendances");
            DropIndex("dbo.TimeTables", new[] { "ClassTypeId" });
            DropIndex("dbo.People", new[] { "GradeId" });
            DropIndex("dbo.SparringDetails", new[] { "OutcomeId" });
            DropIndex("dbo.SparringDetails", new[] { "PersonId" });
            DropIndex("dbo.SparringDetails", new[] { "AttendanceId" });
            DropIndex("dbo.Attendances", new[] { "TimeTableId" });
            DropTable("dbo.ClassTypes");
            DropTable("dbo.TimeTables");
            DropTable("dbo.Grades");
            DropTable("dbo.People");
            DropTable("dbo.Outcomes");
            DropTable("dbo.SparringDetails");
            DropTable("dbo.Attendances");
        }
    }
}
