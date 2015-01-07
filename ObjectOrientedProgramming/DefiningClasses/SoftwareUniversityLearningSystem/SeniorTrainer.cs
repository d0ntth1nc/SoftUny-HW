using System;

namespace SoftwareUniversityLearningSystem
{
    internal sealed class SeniorTrainer : Trainer
    {
        public SeniorTrainer(string firstName, string lastName, int age)
            : base(firstName, lastName, age) { }

        public void DeleteCourse(string name)
        {
            Console.WriteLine("Deleted course {0}", name);
        }
    }
}
