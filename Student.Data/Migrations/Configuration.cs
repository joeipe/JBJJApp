namespace Student.Data.Migrations
{
    using Student.Domain;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Student.Data.StudentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Student.Data.StudentContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            {
                IList<Grade> defaultGrades = new List<Grade>();

                defaultGrades.Add(new Grade() { Name = "White" });
                defaultGrades.Add(new Grade() { Name = "Blue" });
                defaultGrades.Add(new Grade() { Name = "Purple" });
                defaultGrades.Add(new Grade() { Name = "Brown" });
                defaultGrades.Add(new Grade() { Name = "Black" });

                context.Grades.AddRange(defaultGrades);
            }

            {
                IList<Person> defaultPeople = new List<Person>();

                defaultPeople.Add(new Person() { FirstName = "Alex", LastName = "Santos", GradeId = 5, Stripe = 4 });
                defaultPeople.Add(new Person() { FirstName = "Tony", LastName = "Wu", GradeId = 4, Stripe = 0 });
                defaultPeople.Add(new Person() { FirstName = "Jeremy", LastName = "Ong", GradeId = 4, Stripe = 0 });
                defaultPeople.Add(new Person() { FirstName = "Tin", LastName = "Nguyen", GradeId = 4, Stripe = 0 });
                defaultPeople.Add(new Person() { FirstName = "Leonard", LastName = "Correa", GradeId = 3, Stripe = 2 });
                defaultPeople.Add(new Person() { FirstName = "Nick", LastName = "La", GradeId = 3, Stripe = 0 });
                defaultPeople.Add(new Person() { FirstName = "Gareth", LastName = "Porter", GradeId = 3, Stripe = 0 });
                defaultPeople.Add(new Person() { FirstName = "Kevin", LastName = "Phuong", GradeId = 2, Stripe = 1 });
                defaultPeople.Add(new Person() { FirstName = "Alex", LastName = "Tasio", GradeId = 3, Stripe = 0 });
                defaultPeople.Add(new Person() { FirstName = "Thushara", LastName = "Amendra", GradeId = 4, Stripe = 0 });
                defaultPeople.Add(new Person() { FirstName = "Peppe", LastName = "Impala", GradeId = 3, Stripe = 0 });

                context.People.AddRange(defaultPeople);
            }
        }
    }
}
