namespace Student.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPersonListView : DbMigration
    {
        public override void Up()
        {
            Sql
                (
                @"CREATE VIEW Student.PersonList AS
                      SELECT P.Id, P.FirstName + ' ' + P.LastName FullName, P.Stripe, G.Name Grade
                      FROM Student.People P
                       inner join Student.Grades G on G.Id=P.GradeId"
                );
        }
        
        public override void Down()
        {
            Sql("DROP VIEW Student.PersonList");
        }
    }
}
