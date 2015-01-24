
using System;
namespace SoftwareUniversityLearningSystem
{
    internal abstract class Person
    {
        private string firstName = string.Empty;
        private string lastName = string.Empty;
        private int age = 0;

        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentException("First name cannot be null or empty!");
                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentException("First name cannot be null or empty!");
                this.lastName = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Age cannot be negative number!");
            }
        }
    }
}