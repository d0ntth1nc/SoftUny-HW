using System.Collections.Generic;
namespace CompanyHierarchy
{
    public interface IManager : IEmployee
    {
        List<IEmployee> Empoyees { get; }
    }
}
