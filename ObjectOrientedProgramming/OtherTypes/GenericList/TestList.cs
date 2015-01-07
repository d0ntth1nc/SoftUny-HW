using System;

namespace GenericListProject
{
    class TestList
    {
        static void Main(string[] args)
        {
            var list = new GenericList<int>();
            Console.WriteLine("Using GenericList version {0}\n", list.GetVersion());
            for (int i = 0; i < 17; i++)
            {
                list.Add(i);
            }

            Console.WriteLine("Initial: {0}", list);

            list.Insert(4, 9);
            Console.WriteLine("Insert(4, 9): {0}", list);

            list.Remove(9);
            Console.WriteLine("Remove(9): {0}", list);

            Console.WriteLine("IndexOf(6): {0}", list.IndexOf(6));

            list.Clear();
            Console.WriteLine("list.Clear(): {0}", list);
        }
    }
}
