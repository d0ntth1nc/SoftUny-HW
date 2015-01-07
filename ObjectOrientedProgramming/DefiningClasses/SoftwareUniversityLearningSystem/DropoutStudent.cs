using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareUniversityLearningSystem
{
    internal sealed class DropoutStudent : Student
    {
        public DropoutStudent(string firstName, string lastName, int age,
            int studentNumber, float avgGrade)
            : base(firstName, lastName, age, studentNumber, avgGrade) { }

        public string DropoutReason { get; set; }

        public void Reapply()
        {
            Console.WriteLine("Name: {0} {1}", this.FirstName, this.LastName);
            Console.WriteLine("Student number: {0}", this.StudentNumber);
            Console.WriteLine("Age: {0}", this.Age);
            Console.WriteLine("Average grade: {0}", this.AvgGrade);
            Console.WriteLine("Dropout reason: {0}", this.DropoutReason);
        }
    }
}
