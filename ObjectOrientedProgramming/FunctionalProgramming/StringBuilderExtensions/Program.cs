using System;
using System.Linq;
using System.Text;

namespace StringBuilderExtensions
{
    class Program
    {
        static void Main(string[] args)
        {
            var sb = new StringBuilder();
            sb.Append("This is long long long text");
            Console.WriteLine(sb.Substring(5, sb.Length - 5));

            sb.RemoveText("long");
            Console.WriteLine(sb.ToString());

            sb.AppendAll(Enumerable.Range(0, 5));
            Console.WriteLine(sb.ToString());
        }
    }
}
