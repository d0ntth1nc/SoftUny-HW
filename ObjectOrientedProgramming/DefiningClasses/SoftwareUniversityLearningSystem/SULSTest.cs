using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftwareUniversityLearningSystem
{
    class SULSTest
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            var random = new Random();

            persons.Add(new JuniorTrainer("Mashina", "Qka", 120));
            persons.Add(new SeniorTrainer("Mashina1", "Qka2", 120));

            persons.Add(new GraduateStudent("Graduate", "Student", random.Next(1, 60), random.Next(3400, 3500), 3.45F));
            persons.Add(new DropoutStudent("Dropout", "Student", random.Next(1, 60), random.Next(3400, 3500), 4.49F));

            persons.Add(new OnlineStudent("Gosho", "Petkov", random.Next(1, 60), random.Next(3400, 3500), 6.00F));
            persons.Add(new OnlineStudent("Aleksandar", "Aleksandrov", random.Next(1, 60), random.Next(3400, 3500), 6.00F));
            persons.Add(new OnlineStudent("Nafta", "Benzin", random.Next(1, 60), random.Next(3400, 3500), 3.01F));
            persons.Add(new OnlineStudent("Qwe", "asd", random.Next(1, 60), random.Next(3400, 3500), 2.01F));

            persons.Add(new OnsiteStudent("Mitko", "Mitkov", random.Next(1, 60), random.Next(3400, 3500), 3.67F, 4));
            persons.Add(new OnsiteStudent("Aleksei", "Alekseev", random.Next(1, 60), random.Next(3400, 3500), 5.32F, 10));
            persons.Add(new OnsiteStudent("Smotanqk", "Kak", random.Next(1, 60), random.Next(3400, 3500), 5.59F, 29));
            persons.Add(new OnsiteStudent("Prosto", "Student", random.Next(1, 60), random.Next(3400, 3500), 3.00F, 30));

            var currentStudents = persons
                .Where(student => student is CurrentStudent)
                .OrderBy(student => ((CurrentStudent)student).AvgGrade);
            int index = 1;
            foreach (var item in currentStudents)
            {
                var currentStudent = item as CurrentStudent;
                Console.WriteLine("Current Student #{0}", index++);
                Console.WriteLine(currentStudent);
                Console.WriteLine();
            }

            index = 1;
            foreach (var juniorTrainer in persons.Where(x => x is Trainer))
            {
                if (juniorTrainer is JuniorTrainer)
                {
                    (juniorTrainer as JuniorTrainer).CreateCourse("#" + index++);
                }
                else if (juniorTrainer is SeniorTrainer)
                {
                    (juniorTrainer as SeniorTrainer).DeleteCourse("#" + index++);
                }

            }
        }
    }
}