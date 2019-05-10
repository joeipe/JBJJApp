namespace Schedule.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Schedule.ClassTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Schedule.TimeTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DayofWeek = c.Int(nullable: false),
                        StartTimeHr = c.Int(nullable: false),
                        StartTimeMin = c.Int(nullable: false),
                        EndTimeHr = c.Int(nullable: false),
                        EndTimeMin = c.Int(nullable: false),
                        ClassTypeId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Schedule.ClassTypes", t => t.ClassTypeId, cascadeDelete: true)
                .Index(t => t.ClassTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Schedule.TimeTables", "ClassTypeId", "Schedule.ClassTypes");
            DropIndex("Schedule.TimeTables", new[] { "ClassTypeId" });
            DropTable("Schedule.TimeTables");
            DropTable("Schedule.ClassTypes");
        }
    }
}
