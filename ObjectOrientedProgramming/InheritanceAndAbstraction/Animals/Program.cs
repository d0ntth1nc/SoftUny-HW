using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    class Program
    {
        static void Main(string[] args)
        {
            var animals = new List<Animal>();
            animals.Add(new Dog("Alex", 1, Gender.Male));
            animals.Add(new Tomcat("Alex", 2));
            animals.Add(new Kitten("Alex", 3));
            animals.Add(new Frog("Frog", 1, Gender.Female));
            animals.Add(new Cat("Qwe", 2, Gender.Female));

            double dogsAverageAge = animals.Where(x => x is Dog).Select(x => x.Age).Average();
            double tomcatsAverageAge = animals.Where(x => x is Tomcat).Select(x => x.Age).Average();
            double kittensAverageAge = animals.Where(x => x is Kitten).Select(x => x.Age).Average();
            double frogsAverageAge = animals.Where(x => x is Frog).Select(x => x.Age).Average();
            double catsAverageAge = animals.Where(x => x is Cat).Select(x => x.Age).Average();
            Console.WriteLine("Cats average age: {0}", catsAverageAge);
        }
    }
}
