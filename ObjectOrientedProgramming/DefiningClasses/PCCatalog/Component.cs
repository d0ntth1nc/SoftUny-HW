using System;

namespace PCCatalog
{
    internal class Component
    {
        private string name;
        private string details;
        private decimal price;

        public Component(string name, decimal price, string details = null)
        {
            this.Name = name;
            this.Price = price;
            this.Details = details;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                        throw new ArgumentException("Name cannot be empty!");
                
                this.name = value;
            }
        }

        public string Details
        {
            get { return this.details; }
            set
            {
                if (value != null)
                {
                    if (String.IsNullOrEmpty(value))
                        throw new ArgumentException("Details cannot be empty! Use null instead!");
                }
                this.details = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Price cannot be negative!");
                this.price = value;
            }
        }
    }
}
