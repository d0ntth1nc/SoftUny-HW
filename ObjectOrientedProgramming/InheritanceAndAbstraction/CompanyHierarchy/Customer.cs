using System;
using System.Text;

namespace CompanyHierarchy
{
    public class Customer : Employee, ICustomer
    {
        private decimal netPurchaseAmount;

        public Customer(int id, string firstName, string lastName, int salary, Department department, decimal netPurchaseAmount)
            : base(id, firstName, lastName, salary, department)
        {
            this.NetPurchaseAmount = netPurchaseAmount;
        }

        public decimal NetPurchaseAmount
        {
            get { return this.netPurchaseAmount; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Net purchase amount cannot be negative number!");

                this.netPurchaseAmount = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("Net purchase amount: {0}\n", this.NetPurchaseAmount);
        }
    }
}
