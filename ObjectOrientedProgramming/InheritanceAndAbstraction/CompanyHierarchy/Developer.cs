using System.Collections.Generic;
using System.Text;

namespace CompanyHierarchy
{
    public class Developer : Employee, IDeveloper
    {
        public List<IProject> Projects { get; private set; }

        public Developer(int id, string firstName, string lastName, int salary, Department department, params IProject[] projects)
            : base(id, firstName, lastName, salary, department)
        {
            this.Projects = new List<IProject>(projects);
        }
    }
}
