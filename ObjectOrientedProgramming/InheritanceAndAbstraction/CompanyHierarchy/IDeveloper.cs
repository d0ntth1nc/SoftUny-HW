using System.Collections.Generic;
namespace CompanyHierarchy
{
    public interface IDeveloper : IEmployee
    {
        List<IProject> Projects { get; }
    }
}
