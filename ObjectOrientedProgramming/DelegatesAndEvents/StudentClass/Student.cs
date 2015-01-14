using System;

namespace StudentClass
{
    public class Student
    {
        private string name;
        private int age;

        public delegate void PropertyChangedHandler(PropertyChangedEventArgs args);
        public event PropertyChangedHandler OnPropertyChanged;

        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentException("Name cannot be empty!");
                var eventArgs = new PropertyChangedEventArgs("Name", this.name, value);
                this.name = value;
                if (OnPropertyChanged != null) OnPropertyChanged(eventArgs);
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < 0 || value > 200) throw new ArgumentOutOfRangeException("Age must be in range [0...200]!");
                var eventArgs = new PropertyChangedEventArgs("Age", this.age, value);
                this.age = value;
                if (OnPropertyChanged != null) OnPropertyChanged(eventArgs);
            }
        }
    }
}
