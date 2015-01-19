using System;

namespace HumanStudentWorker
{
    class Student : Human
    {
        private string faultyNumber;

        public Student(string firstName, string lastName, string faultyNumber)
            : base(firstName, lastName)
        {
            this.FaultyNumber = faultyNumber;
        }

        public string FaultyNumber
        {
            get { return this.faultyNumber; }
            set
            {
                if (value.Length < 5 || value.Length > 10)
                {
                    throw new ArgumentException("Faulty number can have 5...10 letters/digits!");
                }
                this.faultyNumber = value;
            }
        }
    }
}