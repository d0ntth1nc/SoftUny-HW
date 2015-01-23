using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            List<Task> tasks = new List<Task>();
            for (int id = 0; id < 1000; id++)
            {
                tasks.Add(new Task<string>((tId) =>
                {
                    var taskId = (int)tId;
                    var rand = new Random(taskId);
                    long sum = 0;
                    for (int i = 0; i < 100000; i++)
                    {
                        sum += rand.Next(1000);
                    }
                    //return string.Format("Task {0}: {1}", taskId, sum);
                }, id));
            }
        }
    }
}
