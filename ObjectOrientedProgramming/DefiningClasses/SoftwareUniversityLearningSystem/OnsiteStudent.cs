
namespace SoftwareUniversityLearningSystem
{
    internal sealed class OnsiteStudent : CurrentStudent
    {
        public int VisitsCount { get; set; }

        public OnsiteStudent(string firstName, string lastName, int age,
            int studentNumber, float avgGrade, int visitsCount)
            : base(firstName, lastName, age, studentNumber, avgGrade)
        {
            this.VisitsCount = visitsCount;
        }
    }
}