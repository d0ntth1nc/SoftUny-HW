using System;
using System.Linq;

namespace HumanStudentWorker
{
    class Program
    {
        static void Main(string[] args)
        {
            var rd = new Random();
            var students = new Student[10];
            var workers = new Worker[10];
            for (int i = 0; i < 10; i++)
            {
                students[i] = new Student("Alex", "Alex", rd.Next(10000, 99999).ToString());
                workers[i] = new Worker("Alex", "Alex", rd.NextDouble() * 999, rd.Next(1, 8));
            }
            var sortedStudents = students.OrderBy(x => x.FaultyNumber);
            var sortedWorkers = workers.OrderByDescending(x => x.MoneyPerHour());
            var humans = sortedStudents.Cast<Human>()
                .Union(sortedWorkers)
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName);
        }
    }
}
