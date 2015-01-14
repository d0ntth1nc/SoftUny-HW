using System.Collections.Generic;

namespace ClassStudent
{
    class Student
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }
        public int FacultyNumber { get; private set; }
        public int Phone { get; private set; }
        public string Email { get; private set; }
        public IList<int> Marks { get; private set; }
        public int GroupNumber { get; private set; }
        public string GroupName { get; set; }

        public Student(string fname, string lname, int age, int fnumber, int phone, string email, IList<int> marks, int gnumber)
        {
            this.FirstName = fname;
            this.LastName = lname;
            this.Age = age;
            this.FacultyNumber = fnumber;
            this.Phone = phone;
            this.Email = email;
            this.Marks = marks;
            this.GroupNumber = gnumber;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.FirstName, this.LastName);
        }
    }
}