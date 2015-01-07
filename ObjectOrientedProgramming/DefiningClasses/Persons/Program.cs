using System;

namespace Persons
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var person = new Person("Aleksandur", 21);
                Console.WriteLine(person);

                var person2 = new Person("Sashe", 30, "d0ntth1nc@gmail.com");
                Console.WriteLine(person2);

                var person3 = new Person("Sashe", 30, "d0ntth1ncgmail.com");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
