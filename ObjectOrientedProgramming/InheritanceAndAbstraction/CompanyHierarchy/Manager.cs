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
    }
}
