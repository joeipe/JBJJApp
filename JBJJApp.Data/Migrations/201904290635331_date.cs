namespace JBJJApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class date : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendances", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Attendances", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.SparringDetails", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.SparringDetails", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Outcomes", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Outcomes", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.People", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.People", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Grades", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Grades", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.TimeTables", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.TimeTables", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ClassTypes", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ClassTypes", "UpdatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ClassTypes", "UpdatedDate");
            DropColumn("dbo.ClassTypes", "CreatedDate");
            DropColumn("dbo.TimeTables", "UpdatedDate");
            DropColumn("dbo.TimeTables", "CreatedDate");
            DropColumn("dbo.Grades", "UpdatedDate");
            DropColumn("dbo.Grades", "CreatedDate");
            DropColumn("dbo.People", "UpdatedDate");
            DropColumn("dbo.People", "CreatedDate");
            DropColumn("dbo.Outcomes", "UpdatedDate");
            DropColumn("dbo.Outcomes", "CreatedDate");
            DropColumn("dbo.SparringDetails", "UpdatedDate");
            DropColumn("dbo.SparringDetails", "CreatedDate");
            DropColumn("dbo.Attendances", "UpdatedDate");
            DropColumn("dbo.Attendances", "CreatedDate");
        }
    }
}
