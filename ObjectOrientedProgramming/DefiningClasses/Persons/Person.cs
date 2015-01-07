using System;

namespace Persons
{
    internal class Person
    {
        private string name;
        private int age;
        private string email;

        public Person(string name, int age, string email)
        {
            this.Name = name;
            this.Age = age;
            this.Email = email;
        }

        public Person(string name, int age)
            : this(name, age, null) { }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty!");
                }
                this.name = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < 1 || value > 100 )
                {
                    throw new ArgumentOutOfRangeException("Age must be in the range 1...100!");
                }
                this.age = value;
            }
        }

        public string Email
        {
            get { return this.email; }
            set
            {
                if (value != null)
                {
                    if (value.IndexOf("@") < 1)
                    {
                        throw new ArgumentException("Invalid email! It must contain @!");
                    }
                }
                this.email = value;
            }
        }

        public override string ToString()
        {
            string email = String.Empty;
            if (this.Email != null) email = this.Email;
            return String.Format("Name: {0}, Age: {1}, Email: {2}", this.Name, this.Age, email);
        }
    }
}
