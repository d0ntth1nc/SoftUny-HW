using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClass
{
    class Program
    {
        static void Main(string[] args)
        {
            var student = new Student("Aleks", 21);
            student.OnPropertyChanged += (eventArgs) =>
            {
                Console.WriteLine("Property changed: {0} (from {1} to {2})",
                eventArgs.PropertyName, eventArgs.OldValue, eventArgs.NewValue);
            };
            student.Name = "Vanq";
            student.Age = 25;
        }
    }
}
