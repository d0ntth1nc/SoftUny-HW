namespace StudentSystem.Models
{
    using System;
    using System.Collections.Generic;

    public class Student
    {
        public Student()
        {
            // Please, don`t tell me that this is bad...
            Courses = new HashSet<Course>();
            HomeworkSubmissions = new HashSet<Homework>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime? Birthday { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<Homework> HomeworkSubmissions { get; set; }
    }
}
