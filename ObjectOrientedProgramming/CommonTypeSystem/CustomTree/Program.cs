using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomTree
{
    class Program
    {
        static void Main(string[] args)
        {
            const int itemsCount = 10000;
            
            // Adding consecutive items
            Console.Write("Adding {0} consecutive items: ", itemsCount);
            var tree = new BinarySearchTree<int>(Enumerable.Range(0, itemsCount));
            if (tree.Count == itemsCount)
                Console.WriteLine("Success!");
            else
                Console.WriteLine("Failed!");
            Console.WriteLine();

            // Clearing tree
            Console.Write("Clearing the tree: ");
            tree.Clear();
            if (tree.Count == 0)
                Console.WriteLine("Success!");
            else
                Console.WriteLine("Failed!");
            Console.WriteLine();

            // Adding random numbers
            Console.Write("Adding {0} random numbers: ", itemsCount);
            var random = new Random();
            var numbersAdded = new List<int>();
            for (int i = 0; i < itemsCount; i++)
            {
                try
                {
                    int number = random.Next(0, 99999999);
                    tree.Add(number);
                    numbersAdded.Add(number);
                }
                catch { }
            }
            var diff = numbersAdded.Except(tree);
            if (diff.Count() == 0)
                Console.WriteLine("Success!");
            else
                Console.WriteLine("Failed!");
            Console.WriteLine();

            // Deleting
            int item = tree.ElementAt(500);
            Console.Write("Deleting item {0}: ", item);
            tree.Remove(item);
            if (tree.Contains(item))
                Console.WriteLine("Failed!");
            else
                Console.WriteLine("Success!");

            int item2 = tree.ElementAt(300);
            Console.Write("Deleting item {0}: ", item2);
            tree.Remove(item2);
            if (tree.Contains(item2))
                Console.WriteLine("Failed!");
            else
                Console.WriteLine("Success!");

            int item3 = tree.ElementAt(600);
            Console.Write("Deleting item {0}: ", item3);
            tree.Remove(item3);
            if (tree.Contains(item3))
                Console.WriteLine("Failed!");
            else
                Console.WriteLine("Success!");

            int item4 = tree.ElementAt(463);
            Console.Write("Deleting item {0}: ", item4);
            tree.Remove(item4);
            if (tree.Contains(item4))
                Console.WriteLine("Failed!");
            else
                Console.WriteLine("Success!");
            Console.WriteLine();

            // Check the count now
            Console.Write("Check for consistency: ");
            var diff1 = numbersAdded
                .Where(x => x != item && x != item2 && x != item3 && x != item4)
                .Except(tree);
            if (diff1.Count() > 0)
                Console.WriteLine("Failed!");
            else
                Console.WriteLine("Success!");
            Console.WriteLine();

            // Clone
            Console.Write("Cloning tree: ");
            var clone = (BinarySearchTree<int>)tree.Clone();
            if (clone.Count == tree.Count && !Object.ReferenceEquals(clone, tree))
                Console.WriteLine("Success!");
            else
                Console.WriteLine("Failed!");

            Console.ReadLine();
        }
    }
}
