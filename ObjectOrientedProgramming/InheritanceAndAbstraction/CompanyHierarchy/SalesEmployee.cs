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

        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString());
            sb.AppendLine("Employee type: SalesEmployee\n");
            sb.AppendLine("Sales:");
            int index = 1;
            foreach (var sale in this.Sales)
            {
                sb.AppendFormat("{0}. {1}\n", index++, sale);
            }
            return sb.ToString();
        }
    }
}
