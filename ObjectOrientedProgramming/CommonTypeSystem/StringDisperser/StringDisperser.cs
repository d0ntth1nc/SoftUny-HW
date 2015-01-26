using System;
using System.Collections.Generic;

namespace StringDisperser
{
    public class StringDisperser : ICloneable, IComparable<StringDisperser>, IEnumerable<char>
    {
        public StringDisperser(params string[] strings)
        {
            this.Strings = new List<string>(strings);
        }

        public List<string> Strings { get; private set; }

        public IEnumerator<char> GetEnumerator()
        {
            foreach (var stringItem in this.Strings)
            {
                foreach (var character in stringItem)
                {
                    yield return character;
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public int CompareTo(StringDisperser other)
        {
            return string.Join("", this.Strings).CompareTo(string.Join("", other.Strings));
        }

        public object Clone()
        {
            return new StringDisperser(this.Strings.ToArray());
        }
    }
}
