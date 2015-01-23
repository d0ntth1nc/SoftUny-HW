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

        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString());
            sb.AppendLine("Employee type: Developer\n");
            sb.AppendLine("Projects:");
            int index = 1;
            foreach (var project in this.Projects)
            {
                sb.AppendFormat("{0}. {1}\n", index++, project);
            }
            return sb.ToString();
        }
    }
}
