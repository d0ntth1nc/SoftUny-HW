using System;
using System.Collections.Generic;
using System.Text;

namespace StringBuilderExtensions
{
    public static class StringBuilderExtensions
    {
        public static string Substring(this StringBuilder sb, int index, int length)
        {
            if (index < 0 || index >= sb.Length) throw new ArgumentOutOfRangeException("Invalid index!");
            if (length <= 0 || index + length > sb.Length) throw new ArgumentOutOfRangeException("Invalid length!");
            var buffer = new char[length];
            for (int i = index, counter = 0; counter < length; i++, counter++)
            {
                buffer[counter] = sb[i];
            }
            return new string(buffer);
        }

        public static StringBuilder RemoveText(this StringBuilder sb, string text)
        {
            return sb.Replace(text, "");
        }

        public static StringBuilder AppendAll<T>(this StringBuilder sb, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                sb.Append(item.ToString());
            }
            return sb;
        }
    }
}
