
using System;
namespace SoftwareUniversityLearningSystem
{
    internal sealed class OnsiteStudent : CurrentStudent
    {
        private int visitsCount = 0;

        public OnsiteStudent(string firstName, string lastName, int age,
            int studentNumber, float avgGrade, int visitsCount)
            : base(firstName, lastName, age, studentNumber, avgGrade)
        {
            this.VisitsCount = visitsCount;
        }

        public int VisitsCount
        {
            get { return this.visitsCount; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("This value cannot be negative number!");
                this.visitsCount = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("\nVisits count: {0}", this.VisitsCount);
        }
    }
}