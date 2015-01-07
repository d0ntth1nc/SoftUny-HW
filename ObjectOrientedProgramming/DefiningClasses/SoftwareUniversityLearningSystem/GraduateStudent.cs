
namespace SoftwareUniversityLearningSystem
{
    internal sealed class GraduateStudent : Student
    {
        public GraduateStudent(string firstName, string lastName, int age,
            int studentNumber, float avgGrade)
            : base(firstName, lastName, age, studentNumber, avgGrade) { }
    }
}