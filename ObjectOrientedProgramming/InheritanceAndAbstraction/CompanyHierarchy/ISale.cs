using System;
namespace CompanyHierarchy
{
    public interface ISale
    {
        DateTime Date { get; set; }
        string Name { get; set; }
        decimal Price { get; set; }
    }
}
