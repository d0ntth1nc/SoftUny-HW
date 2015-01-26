using System;
using System.Collections.Generic;
using System.Text;

namespace Customer
{
    public class Customer : ICloneable, IComparable<Customer>
    {
        public Customer(string firstName, string middleName, string lastName,
            long id, string address, int mobilePhone, string email, CustomerType type, params Payment[] payments)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.ID = id;
            this.PermanentAddress = address;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.CustomerType = type;
            this.Payments = new List<Payment>(payments);
        }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public long ID { get; set; }
        public string PermanentAddress { get; set; }
        public int MobilePhone { get; set; }
        public string Email { get; set; }
        public List<Payment> Payments { get; set; }
        public CustomerType CustomerType { get; set; }

        public static bool operator==(Customer left, Customer right)
        {
            return left.Equals(right);
        }

        public static bool operator!=(Customer left, Customer right)
        {
            return !left.Equals(right);
        }

        public override bool Equals(object obj)
        {
            var customer = obj as Customer;
            return customer.FirstName == this.FirstName &&
                customer.MiddleName == this.MiddleName &&
                customer.LastName == this.LastName &&
                customer.ID == this.ID &&
                customer.PermanentAddress == this.PermanentAddress &&
                customer.MobilePhone == this.MobilePhone &&
                customer.Email == this.Email &&
                customer.CustomerType == this.CustomerType;
        }

        public override int GetHashCode()
        {
            return (int)this.ID ^ (int)this.CustomerType ^ this.FirstName.Length ^ this.LastName.Length ^ this.MiddleName.Length;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("First name: {0}\n", this.FirstName);
            sb.AppendFormat("Middle name: {0}\n", this.MiddleName);
            sb.AppendFormat("Last name: {0}\n", this.LastName);
            sb.AppendFormat("ID: {0}\n", this.ID);
            sb.AppendFormat("Permanent address: {0}\n", this.PermanentAddress);
            sb.AppendFormat("Mobile phone: {0}\n", this.MobilePhone);
            sb.AppendFormat("Email: {0}\n", this.Email);
            sb.AppendFormat("Customer type: {0}\n", this.CustomerType);
            sb.AppendFormat("Payments count: {0}\n", this.Payments.Count);
            return sb.ToString();
        }

        public object Clone()
        {
            var clonedPayments = new Payment[this.Payments.Count];
            int index = 0;
            foreach (var payment in this.Payments)
            {
                clonedPayments[index++] = (Payment)payment.Clone();
            }
            return new Customer(this.FirstName, this.MiddleName, this.LastName,
                this.ID, this.PermanentAddress, this.MobilePhone, this.Email, this.CustomerType, clonedPayments);
        }

        public int CompareTo(Customer other)
        {
            if (this.Equals(other)) return 0;

            string thisFullName =
                string.Format("{0} {1} {2}", this.FirstName, this.MiddleName, this.LastName);
            string otherFullName =
                string.Format("{0} {1} {2}", other.FirstName, other.MiddleName, other.LastName);
            if (thisFullName != otherFullName)
            {
                return thisFullName.CompareTo(otherFullName);
            }

            if (this.ID == other.ID) return 0;
            else if (this.ID < other.ID) return -1;
            else return 1;
        }
    }
}
