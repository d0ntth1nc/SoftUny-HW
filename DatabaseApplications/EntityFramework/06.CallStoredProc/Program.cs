namespace _06.CallStoredProc
{
    using System.Linq;
    using _01.SoftUniDbContext;

    class Program
    {
        static void Main(string[] args)
        {
            var context = new SoftUniEntities();
            var projects = context.GetProjectsByEmployee("Ruth", "Ellerbrock");
            foreach (var project in projects)
            {
                System.Console.WriteLine("{0} - {1}..., {2}",
                    project.Name, project.Description.Substring(0, 30),
                    project.StartDate);
            }
        }
    }
}
