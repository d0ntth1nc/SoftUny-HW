namespace Homework
{
    using _01.SoftUniDbContext;

    public class EmployeeDAO
    {
        private static SoftUniEntities softuniEntities = null;

        static EmployeeDAO()
        {
            softuniEntities = new SoftUniEntities();
        }

        public static void Add(Employee employee)
        {
            softuniEntities.Employees.Add(employee);
            softuniEntities.SaveChanges();
        }

        public static Employee FindByKey(object key)
        {
            return softuniEntities.Employees.Find(key);
        }

        public static void Modify(Employee employee)
        {
            softuniEntities.SaveChanges();
        }

        public static void Delete(Employee employee)
        {
            softuniEntities.Employees.Remove(employee);
            softuniEntities.SaveChanges();
        }
    }
}
