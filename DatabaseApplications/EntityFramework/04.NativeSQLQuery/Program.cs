namespace _04.NativeSQLQuery
{
    using System;
    using System.Linq;
    using _01.SoftUniDbContext;

    class Program
    {
        static void Main(string[] args)
        {
            var context = new SoftUniEntities();
            var totalCount = context.Employees.Count();
            var stopWatch = new System.Diagnostics.Stopwatch();

            stopWatch.Start();
            var names = GetNamesWithNativeQuery(context);
            stopWatch.Stop();
            Console.WriteLine("Native: {0}", stopWatch.Elapsed);
            //Console.WriteLine(string.Join(", ", names));

            stopWatch.Restart();
            var names2 = GetNamesWithLinqQuery(context);
            stopWatch.Stop();
            Console.WriteLine("Linq: {0}", stopWatch.Elapsed);
            //Console.WriteLine(string.Join(", ", names2));
        }

        static string[] GetNamesWithLinqQuery(SoftUniEntities context)
        {
            var employeeNamesQuery = from employee in context.Employees 
                                     where employee.Projects.Any(p => p.StartDate.Year == 2002) 
                                     select employee.FirstName;

            return employeeNamesQuery.ToArray();
        }

        static string[] GetNamesWithNativeQuery(SoftUniEntities context)
        {
            const string Query = "SELECT [Extent1].[FirstName] AS [FirstName] FROM [dbo].[Employees] AS [Extent1] WHERE  EXISTS (SELECT  1 AS [C1] FROM  [dbo].[EmployeesProjects] AS [Extent2]" +
                "INNER JOIN [dbo].[Projects] AS [Extent3] ON [Extent3].[ProjectID] = [Extent2].[ProjectID]" +
                "WHERE ([Extent1].[EmployeeID] = [Extent2].[EmployeeID]) AND (2002 = (DATEPART (year, [Extent3].[StartDate]))) AND (DATEPART (year, [Extent3].[StartDate]) IS NOT NULL) ) ";

            var result = context.Database.SqlQuery<string>(Query);
            return result.ToArray();
        }
    }
}
