namespace _05.ConcurrentChanges
{
    using System.Linq;
    using _01.SoftUniDbContext;

    class Program
    {
        static void Main(string[] args)
        {
            var context = new SoftUniEntities();
            var context2 = new SoftUniEntities();

            var town = context.Towns.Where(t => t.TownID == 1).First();
            var town2 = context2.Towns.Where(t => t.TownID == 1).First();

            town.Name = "Moscow";
            town.Name = "Samara";

            context.SaveChanges();
            context2.SaveChanges();
        }
    }
}
