namespace StudentSystem.Data
{
    using System.Data.Entity;
    using Models;
    using StudentSystem.Data.Migrations;

    public class ForumSystemContext : DbContext
    {
        public ForumSystemContext()
            : base("ForumSystemContext")
        {
            Database.SetInitializer(
                //new DropCreateDatabaseAlways<ForumSystemContext>());
                new MigrateDatabaseToLatestVersion<ForumSystemContext, Configuration>());
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Homework> Homeworks { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<License> Licenses { get; set; }
    }
}
