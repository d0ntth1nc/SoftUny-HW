using System.Collections.Generic;
namespace CompanyHierarchy
{
    public interface ISalesEmployee : IEmployee
    {
        List<ISale> Sales { get; }
    }
}
