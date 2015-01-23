using System.Collections.Generic;
using System.Text;

namespace CompanyHierarchy
{
    public class Manager : Employee,  IManager
    {
        public List<IEmployee> Empoyees { get; private set; }

        public Manager(int id, string firstName, string lastName, int salary, Department department, params IEmployee[] employees)
            : base(id, firstName, lastName, salary, department)
        {
            this.Empoyees = new List<IEmployee>(employees);
        }

        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString());
            sb.AppendLine("Employee type: Manager\n");
            sb.AppendLine("Employees under control:");
            int index = 1;
            foreach (var employee in this.Empoyees)
            {
                sb.AppendFormat("{0}. {1}\n", index++, employee.FullName);
            }
            return sb.ToString();
        }
    }
}
