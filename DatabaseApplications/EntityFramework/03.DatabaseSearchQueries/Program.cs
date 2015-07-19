namespace _03.DatabaseSearchQueries
{
    using _01.SoftUniDbContext;
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    class Program
    {
        static SoftUniEntities context = new SoftUniEntities();

        static void Main(string[] args)
        {
            var employeesByStartDate = GetEmployeesByStartDate();
            var addresses = GetAddresses();
            var employee = GetEmployeeById(147);
            var departments = GetAllDepartmentsWithMoreThan5Employees();
        }

        static dynamic[] GetEmployeesByStartDate()
        {
            var employeesQuery = from employee in context.Employees
                                 where employee.Projects.Any(p => p.StartDate.Year >= 2001 &&
                                     p.StartDate.Year <= 2003)
                                 select new
                                 {
                                     employee.FirstName,
                                     employee.LastName,
                                     ManagerName = employee.Employee1.FirstName,
                                     Projects = from project in employee.Projects
                                                where project.StartDate.Year >= 2001
                                                where project.StartDate.Year <= 2003
                                                select new
                                                {
                                                    project.Name,
                                                    project.StartDate,
                                                    project.EndDate
                                                }
                                 };

            return employeesQuery.ToArray();
        }

        static dynamic[] GetAddresses()
        {
            var addresses = from address in context.Addresses
                            select new
                            {
                                Text = address.AddressText,
                                TownName = address.Town.Name,
                                EmployeeCount = address.Employees.Count
                            };

            return addresses
                .OrderByDescending(a => a.EmployeeCount)
                .ThenBy(a => a.TownName)
                .Take(10)
                .ToArray();
        }

        static dynamic GetEmployeeById(int id)
        {
            var employeeQuery = from employee in context.Employees
                                where employee.EmployeeID == id
                                select new
                                {
                                    employee.FirstName,
                                    employee.LastName,
                                    employee.JobTitle,
                                    Projects = from project in employee.Projects
                                               orderby project.Name ascending
                                               select project.Name
                                };

            return employeeQuery.First();
        }

        static dynamic[] GetAllDepartmentsWithMoreThan5Employees()
        {
            var departmentsQuery = from department in context.Departments
                                   where department.Employees.Count > 5
                                   orderby department.Employees.Count ascending
                                   select new
                                   {
                                       DepartmentName = department.Name,
                                       ManagerName = department.Employee.FirstName,
                                       Employees = from employee in department.Employees
                                                   select new
                                                   {
                                                       employee.FirstName,
                                                       employee.LastName,
                                                       employee.HireDate,
                                                       employee.JobTitle
                                                   }
                                   };

            return departmentsQuery.ToArray();
        }
    }
}
