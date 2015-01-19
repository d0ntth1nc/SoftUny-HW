using System.Collections.Generic;
using System.Text;

namespace CompanyHierarchy
{
    public class SalesEmployee : Employee, ISalesEmployee
    {
        public List<ISale> Sales { get; private set; }

        public SalesEmployee(int id, string firstName, string lastName, int salary, Department department, params ISale[] sales)
            : base(id, firstName, lastName, salary, department)
        {
            this.Sales = new List<ISale>(sales);
        }
    }
}
