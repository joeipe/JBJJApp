namespace Student.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Student.Grades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Student.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        GradeId = c.Int(nullable: false),
                        Stripe = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Student.Grades", t => t.GradeId, cascadeDelete: true)
                .Index(t => t.GradeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Student.People", "GradeId", "Student.Grades");
            DropIndex("Student.People", new[] { "GradeId" });
            DropTable("Student.People");
            DropTable("Student.Grades");
        }
    }
}
