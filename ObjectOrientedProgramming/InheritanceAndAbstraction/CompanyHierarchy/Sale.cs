using System;

namespace CompanyHierarchy
{
    public class Sale : ISale
    {
        private string name;
        private decimal price;

        public DateTime Date { get; set; }

        public Sale(string name, DateTime date, decimal price)
        {
            this.Name = name;
            this.Date = date;
            this.Price = price;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentException("Sale name cannot be null or empty!");
                this.name = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Price cannot be negative number!");
                this.price = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Name: {0}, Date: {1}, Price: {2:0.0000}", this.Name, this.Date, this.Price);
        }
    }
}
