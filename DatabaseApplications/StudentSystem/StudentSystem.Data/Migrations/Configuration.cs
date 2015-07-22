namespace StudentSystem.Data.Migrations
{
    using StudentSystem.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentSystem.Data.ForumSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(StudentSystem.Data.ForumSystemContext context)
        {
            if (context.Courses.Any() || context.Homeworks.Any() || context.Resources.Any() || context.Students.Any())
            {
                return;
            }

            context.Courses.AddRange(new Course[]
            {
                new Course()
                {
                    Name = "DatabaseApps",
                    Description = "Working with databases.",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddMonths(1),
                    Price = 200
                },
                new Course()
                {
                    Name = "JsApps",
                    Description = "Working with JS.",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddMonths(1),
                    Price = 300
                }
            });
            context.SaveChanges();

            context.Students.AddRange(new Student[]
            {
                new Student()
                {
                    Name = "Sashe",
                    RegistrationDate = DateTime.Now,
                    Courses = context.Courses.ToList()
                },
                new Student()
                {
                    Name = "Goshe",
                    RegistrationDate = DateTime.Now,
                    Courses = context.Courses.ToList()
                },
                new Student()
                {
                    Name = "Toshe",
                    RegistrationDate = DateTime.Now,
                    Courses = context.Courses.ToList()
                },
                new Student()
                {
                    Name = "Moshe",
                    RegistrationDate = DateTime.Now,
                    Courses = context.Courses.ToList()
                },
                new Student()
                {
                    Name = "Mishe",
                    RegistrationDate = DateTime.Now,
                    Courses = context.Courses.ToList()
                },
                new Student()
                {
                    Name = "Tishe",
                    RegistrationDate = DateTime.Now,
                    Courses = context.Courses.ToList()
                }
            });
            context.SaveChanges();

            context.Homeworks.AddRange(new Homework[]
            {
                new Homework()
                {
                    Content = "Qkoto",
                    ContentType = ContentType.Application,
                    SubmissionDate = DateTime.Now,
                    StudentId = 1,
                    CourseId = 5
                },
                new Homework()
                {
                    Content = "Empty homework lol",
                    ContentType = ContentType.Application,
                    SubmissionDate = DateTime.Now,
                    StudentId = 1,
                    CourseId = 6
                }
            });
            context.SaveChanges();

            context.Licenses.AddOrUpdate(l => l.Name,
                new License() { Name = "MIT" },
                new License() { Name = "BSD" },
                new License() { Name = "ISC" });
            context.SaveChanges();

            context.Resources.AddOrUpdate(r => r.Name,
                new Resource()
                {
                    Name = "Lesbiiki",
                    Type = ResourceType.Video,
                    CourseId = 5,
                    Licenses = context.Licenses.ToArray(),
                    URL = "http://www.youporn.com/watch/10939773/lesbianolderyounger-riley-reid-and-sovereign-syre-facesit/?from=vbwn"
                },
                new Resource()
                {
                    Name = "SAdasdsad",
                    Type = ResourceType.Video,
                    CourseId = 6,
                    Licenses = context.Licenses.ToArray(),
                    URL = "http://www.youporn.com/watch/10939773/lesbianolderyounger-riley-reid-and-sovereign-syre-facesit/?from=vbwn"
                },
                new Resource()
                {
                    Name = "RRerewr",
                    Type = ResourceType.Video,
                    CourseId = 5,
                    URL = "http://www.youporn.com/watch/10939773/lesbianolderyounger-riley-reid-and-sovereign-syre-facesit/?from=vbwn"
                },
                new Resource()
                {
                    Name = "sdddd",
                    Type = ResourceType.Video,
                    CourseId = 6,
                    URL = "http://www.youporn.com/watch/10939773/lesbianolderyounger-riley-reid-and-sovereign-syre-facesit/?from=vbwn"
                },
                new Resource()
                {
                    Name = "6666",
                    Type = ResourceType.Video,
                    CourseId = 5,
                    URL = "http://www.youporn.com/watch/10939773/lesbianolderyounger-riley-reid-and-sovereign-syre-facesit/?from=vbwn"
                },
                new Resource()
                {
                    Name = "Girlfriends",
                    Type = ResourceType.Video,
                    CourseId = 6,
                    URL = "http://www.youporn.com/watch/8235367/girlfriends-sensually-having-sex/?from=vbwn"
                });
            context.SaveChanges();
        }
    }
}
