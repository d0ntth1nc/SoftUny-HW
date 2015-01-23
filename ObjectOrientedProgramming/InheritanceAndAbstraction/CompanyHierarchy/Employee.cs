using System;

namespace CompanyHierarchy
{
    public class Employee : Person, IEmployee
    {
        private decimal salary;
        public Department Department { get; set; }

        public Employee(int id, string firstName, string lastName, decimal salary, Department department)
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
            this.Department = department;
        }

        public decimal Salary
        {
            get { return this.salary; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Salary cannot be negative number!");
                this.salary = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("Salary: {0}\nDepartment: {1}\n", this.Salary, this.Department.ToString());
        }
    }
}