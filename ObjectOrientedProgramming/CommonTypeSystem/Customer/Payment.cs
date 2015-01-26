using System;

namespace Customer
{
    public class Payment : ICloneable
    {
        private string productName;
        private decimal price;

        public Payment(string productName, decimal price)
        {
            this.ProductName = productName;
            this.Price = price;
        }

        public string ProductName
        {
            get { return this.productName; }
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentException("Product name cannot be null or empty!");
                this.productName = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Price cannot be negative number!");
            }
        }

        public object Clone()
        {
            return new Payment(this.ProductName, this.Price);
        }
    }
}
