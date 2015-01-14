using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassStudent
{
    class Program
    {
        private static List<Student> CreateStudents()
        {
            var random = new Random();
            var students = new List<Student>();
            students.Add(new Student("Aleksandur", "Seferinkyn", 21, random.Next(100000, 999999),
                random.Next(0890000000, 0899999999), "d0ntth1nc@gmail.com",
                new List<int>(new[] { 6, 6, 6, 6, 6, 5, 6, 4, 6 }), random.Next(1, 3)));
            students.Add(new Student("Gosho", "Georgiev", random.Next(14, 40), random.Next(100000, 999999),
                random.Next(0890000000, 0899999999), "gosho@gmail.com",
                new List<int>(new[] { 6, 2, 3, 6, 4, 5, 5, 4, 6 }), random.Next(1, 3)));
            students.Add(new Student("Momchil", "Popov", random.Next(14, 40), random.Next(100000, 999999),
                random.Next(0890000000, 0899999999), "momchil@abv.bg",
                new List<int>(new[] { 6, 2, 3, 6, 6, 5, 2, 4, 3 }), random.Next(1, 3)));
            students.Add(new Student("Marian", "Bikov", random.Next(14, 40), random.Next(100000, 999999),
                random.Next(0890000000, 0899999999), "marian@abv.bg",
                new List<int>(new[] { 6, 4, 3, 6, 5, 5, 6, 4, 4 }), random.Next(1, 3)));
            students.Add(new Student("Gergana", "Georgieva", random.Next(14, 40), random.Next(100000, 999999),
                random.Next(0890000000, 0899999999), "gergana@gmail.com",
                new List<int>(new[] { 6, 6, 6, 6, 6, 6, 6, 6, 6 }), random.Next(1, 3)));
            students.Add(new Student("Veronika", "Ivanova", random.Next(14, 40), random.Next(100000, 999999),
                random.Next(0890000000, 0899999999), "veronika@gmail.com",
                new List<int>(new[] { 6, 6, 6, 6, 6, 6, 6, 6, 6 }), random.Next(1, 3)));
            students.Add(new Student("Lara", "Croft", random.Next(14, 40), random.Next(100000, 999999),
                random.Next(0890000000, 0899999999), "lara@gmail.com",
                new List<int>(new[] { 6, 3, 3, 6, 6, 5, 3, 4, 6 }), random.Next(1, 3)));
            students.Add(new Student("Desislava", "Etova", random.Next(14, 40), random.Next(100000, 999999),
                random.Next(0890000000, 0899999999), "desislava@abv.bg",
                new List<int>(new[] { 6, 2, 6, 2, 6, 5, 6, 4, 6 }), random.Next(1, 3)));
            students.Add(new Student("Rebeca", "Croft", random.Next(14, 40), random.Next(100000, 999999),
                random.Next(0890000000, 0899999999), "rebeca@gmail.com",
                new List<int>(new[] { 6, 2, 6, 2, 6, 5, 6, 4, 2 }), random.Next(1, 3)));
            return students;
        }

        private static void PrintStudents(IEnumerable<dynamic> students, string msg)
        {
            Console.WriteLine(msg);
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
            Console.ReadLine();
            Console.Clear();
        }

        private static void StudentsByGroups(IEnumerable<Student> students)
        {
            int i = 0;
            foreach (var student in students)
            {
                if (i++ % 2 == 0)
                {
                    student.GroupName = "Even";
                }
                else
                {
                    student.GroupName = "Odd";
                }
            }

            var groupedStudents =
                from student in students
                group student by student.GroupName into g
                select new { Group = g };
            foreach (var group in groupedStudents)
            {
                Console.WriteLine("{0}:", group.Group.Key);
                foreach (var student in group.Group)
                {
                    Console.WriteLine(student);
                }
            }
            Console.ReadLine();
            Console.Clear();
        }

        private static void StudentsJoin(IEnumerable<Student> students)
        {
            var specialties = new StudentsSpecialty[]
                {
                 new StudentsSpecialty(),  new StudentsSpecialty(),  
                 new StudentsSpecialty(),  new StudentsSpecialty(), 
                };
            specialties[0].SpecialtyName = "Web Designer";
            specialties[0].FaciltyNumber = students.ElementAt(0).FacultyNumber;
            specialties[1].SpecialtyName = "Web Designer";
            specialties[1].FaciltyNumber = students.ElementAt(1).FacultyNumber;
            specialties[2].SpecialtyName = "PHP Developer";
            specialties[2].FaciltyNumber = students.ElementAt(1).FacultyNumber;
            specialties[3].SpecialtyName = "C# Developer";
            specialties[3].FaciltyNumber = students.ElementAt(0).FacultyNumber;

            var studentsAndSpecialties =
                from student in students
                join specialty in specialties on student.FacultyNumber equals specialty.FaciltyNumber
                select new { StudentName = student.ToString(), FacNum = specialty.FaciltyNumber, Specialty = specialty.SpecialtyName };

            foreach (var student in studentsAndSpecialties)
            {
                Console.WriteLine("{0} {1} {2}", student.StudentName, student.Specialty, student.FacNum);
            }
        }

        static void Main(string[] args)
        {
            var students = CreateStudents();

            //Problem 4.	Students by Group
            var studentsByGroup = students
                .Where(x => x.GroupNumber == 2)
                .OrderBy(x => x.FirstName)
                .Select(x => x.ToString() + " group: " + x.GroupNumber);
            PrintStudents(studentsByGroup, "Students by group: ");

            //Problem 5.	Students by First and Last Name
            var studentsByFirstAndLastName = students
                .Where(x => x.FirstName.CompareTo(x.LastName) < 0);
            PrintStudents(studentsByFirstAndLastName, "Students by first and last name:");

            //Problem 6.	Students by Age
            var studentsByAge = students
                .Where(x => x.Age >= 18 && x.Age <= 24)
                .Select(x => new { FirstName = x.FirstName, LastName = x.LastName, Age = x.Age });
            PrintStudents(studentsByAge, "Students by age:");

            //Problem 7.	Sort Students
            var sortedStudents = students
                .OrderByDescending(x => x.FirstName)
                .ThenByDescending(x => x.LastName);
            var sortedStudentsQuery =
                from student in students
                orderby student.FirstName descending
                orderby student.LastName descending
                select student;
            PrintStudents(sortedStudents, "Sorted students:");

            //Problem 8.	Filter Students by Email Domain
            var studentsByEmail = students
                .Where(x => x.Email.EndsWith("@abv.bg"))
                .Select(x => x.ToString() + " email: " + x.Email);
            PrintStudents(studentsByEmail, "Students by email:");

            //Problem 9.	Filter Students by Phone
            var studentsByPhone = students
                .Where(x => x.Phone.ToString()[3] == 2)
                .Select(x => x.ToString() + " phone: " + x.Phone);
            PrintStudents(studentsByPhone, "Students by Phone:");

            //Problem 10.	Excellent Students
            var excellentStudents = students
                .Where(x => x.Marks.Any(y => y == 6))
                .Select(x => new { FullName = x.FirstName + ' ' + x.LastName, Marks = x.Marks });
            PrintStudents(excellentStudents, "Excellent students:");

            //Problem 11.	Weak Students
            var weakStudents = students
                .Where(x => x.Marks.Where(y => y == 2).Count() == 2);
            PrintStudents(weakStudents, "Weak students:");

            //Problem 12.	Students Enrolled in 2014
            var studentsEnrolledIn2014 = students
                .Where(x => x.FacultyNumber.ToString()[5] == 1 && x.FacultyNumber.ToString()[6] == 4)
                .Select(x => x.ToString() + " faculty number: " + x.FacultyNumber);
            PrintStudents(studentsEnrolledIn2014, "Students enrolled in 2014");

            //Problem 13.    Students by Groups
            StudentsByGroups(students);

            //Problem 14.    Students Joined to Specialties
            StudentsJoin(students);
        }
    }
}