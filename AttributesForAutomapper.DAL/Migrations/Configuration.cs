using System;
using System.Data.Entity.Migrations;
using AttributesForAutomapper.Domain;

namespace AttributesForAutomapper.DAL.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MySampleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MySampleContext context)
        {
            var mine = new Student
            {
                Name = "Morteza",
                Family = "Raeisi",
                Email = "MrRaeisi@outlook.com",
                RegisterDateTime = DateTime.Now.AddYears(-2),
            };
            var amin = new Student
            {
                Name = "Amin",
                Family = "Rafiei",
                Email = "Amin@yahoo.com",
                RegisterDateTime = DateTime.Now.AddYears(-1),
            };
            var john = new Student
            {
                Name = "John",
                Family = "Johni",
                Email = "JohnEmail@johnoo.com",
                RegisterDateTime = DateTime.Now,
            };
            context.Students.Add(mine);
            context.Students.Add(amin);
            context.Students.Add(john);

            context.Books.Add(new Book
            {
                Student = mine,
                Name = "AutoMapper Attr",
                BorrowDateTime = DateTime.Now.AddYears(-3),
                ExpiredDateTime = DateTime.Now.AddYears(-3).AddMonths(1),
                Price = 1000M,
            });
            context.Books.Add(new Book
            {
                Student = mine,
                Name = "Second Book",
                BorrowDateTime = DateTime.Now.AddYears(-3).AddMonths(2),
                ExpiredDateTime = DateTime.Now.AddYears(-3).AddMonths(3),
                Price = 2500M,
            });
            context.Books.Add(new Book
            {
                Student = mine,
                Name = "Hungry Book",
                BorrowDateTime = DateTime.Now.AddYears(-3).AddMonths(5),
                ExpiredDateTime = DateTime.Now.AddYears(-3).AddMonths(6),
                Price = 2500M,
            });

            context.Books.Add(new Book
            {
                Student = amin,
                Name = "Amin Book",
                BorrowDateTime = DateTime.Now.AddYears(-2).AddMonths(2),
                ExpiredDateTime = DateTime.Now.AddYears(-2).AddMonths(3),
                Price = 1200M,
            });
            context.SaveChanges();
        }
    }
}
