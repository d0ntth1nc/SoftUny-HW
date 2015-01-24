
using System;
namespace SoftwareUniversityLearningSystem
{
    internal abstract class Student : Person
    {
        private int studentNumber = 0;
        private float avgGrade = 0;

        public Student(string firstName, string lastName, int age, int studentNumber, float avgGrade)
            : base (firstName, lastName, age)
        {
            this.StudentNumber = studentNumber;
            this.AvgGrade = avgGrade;
        }

        public float AvgGrade
        {
            get { return this.avgGrade; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Avgerage grade cannot be negative number!");
                this.avgGrade = value;
            }
        }

        public int StudentNumber
        {
            get { return this.studentNumber; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Student number cannot be negative number!");
                this.studentNumber = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("\nStudent number: {0}\nAverage grade: {1}", this.StudentNumber, this.AvgGrade);
        }
    }
}
