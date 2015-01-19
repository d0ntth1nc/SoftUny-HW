using System;
namespace CompanyHierarchy
{
    public interface IPerson
    {
        string FirstName { get; set; }
        int Id { get; set; }
        string LastName { get; set; }
        string FullName { get; }
    }
}
