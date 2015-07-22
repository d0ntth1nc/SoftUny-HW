namespace StudentSystem.ConsoleUI
{
    using StudentSystem.Data;
    using System;
    using System.Data.Entity.SqlServer;
    using System.Linq;

    class Program
    {
        static ForumSystemContext s_context = new ForumSystemContext();

        static void Main(string[] args)
        {
            //PrintAllStudents();
            //PrintAllCourses();
            //PrintAllCoursesWithMoreThan5Resources();
            //PrintAllCoursesByActiveDate();
            PrintStudents();
        }

        //⦁	Lists all students and their homework submissions.
        // Select only their names and for each homework - content and content-type.
        static void PrintAllStudents()
        {
            var studentsQuery = from student in s_context.Students
                                select new
                                {
                                    StudentName = student.Name,
                                    Homeworks = from homework in student.HomeworkSubmissions
                                                select new
                                                {
                                                    homework.Content,
                                                    homework.ContentType
                                                }
                                };
            foreach (var student in studentsQuery)
            {
                Console.WriteLine("Student: {0}, Homeworks: {1}",
                    student.StudentName, string.Join(", ", student.Homeworks));
            }
        }

        //⦁	List all courses with their corresponding resources.
        // Select the course name and description and everything for each resource.
        // Order the courses by start date (ascending), then by end date (descending).
        static void PrintAllCourses()
        {
            var coursesQuery = from course in s_context.Courses
                               orderby course.StartDate ascending, course.EndDate descending
                               select new
                               {
                                   CourseName = course.Name,
                                   Description = course.Description,
                                   Resources = course.Resources
                               };
            foreach (var course in coursesQuery)
            {
                Console.WriteLine(course);
            }
        }

        //⦁	List all courses with more than 5 resources.
        // Order them by resources count (descending), then by start date (descending).
        // Select only the course name and the resource count.
        static void PrintAllCoursesWithMoreThan5Resources()
        {
            var coursesQuery = from course in s_context.Courses
                               where course.Resources.Count > 5
                               orderby course.Resources.Count descending, course.StartDate descending
                               select new
                               {
                                   CourseName = course.Name,
                                   ResourcesCount = course.Resources.Count
                               };
            foreach (var course in coursesQuery)
            {
                Console.WriteLine(course);
            }
        }

        //⦁	List all courses which were active on a given date (choose the date depending on the data seeded to ensure there are results),
        // and for each course count the number of students enrolled.
        // Select the course name, start and end date, course duration (difference between end and start date) and number of students enrolled.
        // Order the results by the number of students enrolled (in descending order), then by duration (descending).

        static void PrintAllCoursesByActiveDate()
        {
            var date = DateTime.Now.AddDays(10);
            var coursesQuery = from course in s_context.Courses
                               where course.StartDate <= date && course.EndDate >= date
                               orderby course.Students.Count descending, SqlFunctions.DateDiff("day", course.StartDate, course.EndDate) descending
                               select new
                               {
                                   CourseName = course.Name,
                                   StartDate = course.StartDate,
                                   EndDate = course.EndDate,
                                   Duration = SqlFunctions.DateDiff("day", course.StartDate, course.EndDate),
                                   StudentsEnrolledCount = course.Students.Count
                               };
            foreach (var course in coursesQuery)
            {
                Console.WriteLine(course);
            }
        }

        //⦁	For each student, calculate the number of courses he/she has enrolled in,
        // the total price of these courses and the average price per course for the student.
        //  Select the student name, number of courses, total price and average price.
        // Order the results by total price (descending), then by number of courses (descending) and then by the student's name (ascending).
        static void PrintStudents()
        {
            var studentsQuery = from student in s_context.Students
                                orderby student.Courses.Select(c => c.Price).DefaultIfEmpty().Sum() descending,
                                        student.Courses.Select(c => c.Price).DefaultIfEmpty().Average() descending,
                                        student.Name ascending
                                select new
                                {
                                    StudentName = student.Name,
                                    CoursesCount = student.Courses.Count,
                                    TotalPrice = student.Courses.Select(c => c.Price).DefaultIfEmpty().Sum(),
                                    AveragePrice = student.Courses.Select(c => c.Price).DefaultIfEmpty().Average()
                                };
            foreach (var student in studentsQuery)
            {
                Console.WriteLine(student);
            }
        }
    }
}
