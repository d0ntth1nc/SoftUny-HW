using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        public static void Main()
        {
            try
            {
                // Only get files that begin with the letter "c." 
                string[] dirs = Directory.GetFiles(@"C:\Users\Alex\Documents\Visual Studio 2013\Projects\InheritanceAndAbstraction\CompanyHierarchy.UI\bin\Debug", "*.docx");
                Console.WriteLine("The number of files starting with c is {0}.", dirs.Length);
                foreach (string dir in dirs)
                {
                    var file = File.OpenRead(dir);
                    var sr = new StreamReader(file);
                    Console.WriteLine(sr.ReadToEnd());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }
    }
}
