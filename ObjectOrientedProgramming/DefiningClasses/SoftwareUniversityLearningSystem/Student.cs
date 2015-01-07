
namespace SoftwareUniversityLearningSystem
{
    internal abstract class Student : Person
    {
        public int StudentNumber { get; set; }
        public float AvgGrade { get; set; }

        public Student(string firstName, string lastName, int age, int studentNumber, float avgGrade)
            : base (firstName, lastName, age)
        {
            this.StudentNumber = studentNumber;
            this.AvgGrade = avgGrade;
        }
    }
}
