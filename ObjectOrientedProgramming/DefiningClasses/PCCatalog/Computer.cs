using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PCCatalog
{
    internal class Computer
    {
        private string name;
        private List<Component> components;

        public Computer(string name)
        {
            this.Name = name;
            this.components = new List<Component>();
        }

        public Computer(string name, params Component[] components)
        {
            this.Name = name;
            this.components = new List<Component>(components);
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty!");
                }
                this.name = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.components.Aggregate(0M, (total, component) => total + component.Price );
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("Name: {0}\n", this.Name);
            foreach (var component in this.components)
            {
                sb.AppendFormat("Component name: {0}, price: {1:0.00} leva\n", component.Name, component.Price);
            }
            sb.AppendFormat("Total price: {0:0.00} leva", this.Price);
            return sb.ToString();
        }
    }
}
