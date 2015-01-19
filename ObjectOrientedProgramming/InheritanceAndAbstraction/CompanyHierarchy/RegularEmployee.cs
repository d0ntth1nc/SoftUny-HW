
namespace CompanyHierarchy
{
    public class RegularEmployee : Employee
    {
        public RegularEmployee(int id, string firstName, string lastName, int salary, Department department)
            : base(id, firstName, lastName, salary, department) { }
    }
}
