using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PCCatalog
{
    internal class Computer
    {
        private string name = string.Empty;
        private List<Component> components = new List<Component>();
        private decimal price = 0;

        public Computer(string name)
        {
            this.Name = name;
        }

        public Computer(string name, decimal price)
            : this (name)
        {
            this.Price = price;
        }
        
        public Computer(string name, params Component[] components)
            : this(name)
        {
            this.components.AddRange(components);
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
                if (this.price > 0) return this.price;
                else return this.components.Aggregate(0M, (total, component) => total + component.Price );
            }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Price cannot be negative number!");
                this.price = value;
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
