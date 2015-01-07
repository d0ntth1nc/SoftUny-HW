using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareUniversityLearningSystem
{
    internal sealed class OnlineStudent : CurrentStudent
    {
        public OnlineStudent(string firstName, string lastName, int age,
            int studentNumber, float avgGrade)
            : base(firstName, lastName, age, studentNumber, avgGrade) { }
    }
}