using System;

namespace CompanyHierarchy
{
    public abstract class Person : IPerson
    {
        private int id;
        private string firstName;
        private string lastName;

        public Person(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public int Id
        {
            get { return this.id; }
            set
            {
                if (id < 0) throw new ArgumentOutOfRangeException("ID cannot be negative number!");
                this.id = value;
            }
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
                if (string.IsNullOrEmpty(value)) throw new ArgumentException("Last name cannot be null or empty!");
                this.lastName = value;
            }
        }

        public string FullName
        {
            get { return this.FirstName + ' ' + this.LastName; }
        }

        public override string ToString()
        {
            return string.Format("ID: {0}\nFirstName: {1}\nLastName: {2}\n", this.Id, this.FirstName, this.LastName);
        }
    }
}
