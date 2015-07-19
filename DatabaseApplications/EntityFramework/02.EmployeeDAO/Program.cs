namespace Homework
{
    using System;
    using System.Linq;
    using _01.SoftUniDbContext;

    class Program
    {
        static void Main(string[] args)
        {
            var employee = new Employee()
            {
                FirstName = "Sashe",
                LastName = "Sashev",
                MiddleName = "Sashkov",
                JobTitle = "Developer",
                DepartmentID = 1,
                Salary = 44444,
                HireDate = DateTime.Now
            };

            EmployeeDAO.Add(employee);
            Console.WriteLine(employee.EmployeeID);
        }
    }
}
