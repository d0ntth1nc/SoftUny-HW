using System;
using System.Collections.Generic;
using System.Text;

namespace _04.HtmlDispatcher
{
    public class ElementBuilder
    {
        private string content;
        private List<Tuple<string, string>> attributes = new List<Tuple<string, string>>();
        private string tagName;

        public ElementBuilder(string tagName)
        {
            if (string.IsNullOrEmpty(tagName)) throw new ArgumentException("Tag name cannot be empty!");
            this.tagName = tagName;
        }

        public static string operator *(ElementBuilder element, int multipier)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < multipier; i++)
            {
                sb.Append(element.ToString());
            }
            return sb.ToString();
        }

        public void AddAttribute(string attr, string val)
        {
            if (string.IsNullOrEmpty(attr)) throw new ArgumentException("Attribute name cannot be empty!");
            this.attributes.Add(new Tuple<string, string>(attr, val));
        }

        public void AddContent(string content)
        {
            this.content += content;
        }

        public override string ToString()
        {
            // Build attributes
            var attributes = new StringBuilder();
            foreach (var attribute in this.attributes)
            {
                attributes.AppendFormat(" {0}=\"{1}\"", attribute.Item1, attribute.Item2);
            }

            return string.Format("<{0}{1}>{2}</{0}>", this.tagName, attributes.ToString(), this.content);
        }
    }
}
