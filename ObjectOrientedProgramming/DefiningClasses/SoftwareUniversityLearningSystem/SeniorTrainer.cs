using System;

namespace SoftwareUniversityLearningSystem
{
    internal sealed class SeniorTrainer : Trainer
    {
        public SeniorTrainer(string firstName, string lastName, int age)
            : base(firstName, lastName, age) { }

        public void DeleteCourse(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Course name cannot be null or empty!");
            Console.WriteLine("Deleted course {0}", name);
        }
    }
}
