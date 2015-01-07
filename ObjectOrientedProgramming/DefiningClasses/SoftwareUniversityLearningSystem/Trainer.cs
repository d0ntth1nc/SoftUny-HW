
namespace SoftwareUniversityLearningSystem
{
    internal abstract class Trainer : Person
    {
        public Trainer(string firstName, string lastName, int age)
            : base (firstName, lastName, age) { }

        public void CreateCourse(string name)
        {
            System.Console.WriteLine("Created course {0}", name);
        }
    }
}