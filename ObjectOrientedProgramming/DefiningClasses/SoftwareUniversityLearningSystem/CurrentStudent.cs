
namespace SoftwareUniversityLearningSystem
{
    internal abstract class CurrentStudent : Student
    {
        public CurrentStudent(string firstName, string lastName, int age,
            int studentNumber, float avgGrade)
            : base(firstName, lastName, age, studentNumber, avgGrade) { }

        public int CurrentCourse { get; set; }
    }
}
