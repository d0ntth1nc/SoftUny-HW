using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyHierarchy
{
    public class HierarchyGenerator
    {

        public static IEnumerable<IEmployee> GenerateEmployees()
        {
            var random = new Random();
            var employees = new List<IEmployee>();
            var sales = new List<ISale>();
            sales.Add(new Sale("CPU", DateTime.Now.AddDays(1), (decimal)random.NextDouble() * 1000));
            sales.Add(new Sale("RAM", DateTime.Now.AddDays(2), (decimal)random.NextDouble() * 1000));
            sales.Add(new Sale("GPU", DateTime.Now.AddDays(3), (decimal)random.NextDouble() * 1000));

            employees.Add(new Customer(1, "Alex", "Alex", random.Next(100, 5000), Department.Sales, 2312313123M));

            employees.Add(new SalesEmployee(1, "Dimitar", "Dimitrov", random.Next(100, 5000), Department.Sales, sales.ToArray()));
            employees.Add(new SalesEmployee(2, "Chavdar", "Chavdarov", random.Next(100, 5000), Department.Marketing, sales.ToArray()));
            employees.Add(new SalesEmployee(3, "Qvor", "Qvorov", random.Next(100, 5000), Department.Production, sales.Take(2).ToArray()));

            employees.Add(new Developer(4, "Lazar", "Lazarov", random.Next(100, 5000), Department.Accounting,
                new Project("Homework", DateTime.Now.AddDays(1))));
            employees.Add(new Developer(5, "Atanas", "Atanasov", random.Next(100, 5000), Department.Marketing,
                new Project("Homework", DateTime.Now.AddDays(2))));
            employees.Add(new Developer(6, "Kolio", "Nikolov", random.Next(100, 5000), Department.Production,
                new Project("Homework", DateTime.Now.AddDays(3))));

            employees.Add(new Manager(7, "Ivan", "Ivanov", random.Next(100, 5000), Department.Sales,
                employees.Cast<Employee>().Where(x => x.Department == Department.Sales).ToArray()));
            employees.Add(new Manager(8, "Stoqn", "Stoqnov", random.Next(100, 5000), Department.Marketing,
                employees.Cast<Employee>().Where(x => x.Department == Department.Marketing).ToArray()));
            employees.Add(new Manager(9, "Petar", "Petrov", random.Next(100, 5000), Department.Accounting,
                employees.Cast<Employee>().Where(x => x.Department == Department.Accounting).ToArray()));

            return employees;
        }

        static void Main(string[] args)
        {
            foreach (var employee in GenerateEmployees())
            {
                Console.WriteLine(employee);
            }

            Console.WriteLine(Convert.ToBase64String(BitConverter.GetBytes(123213.2414)));
        }
    }
}
