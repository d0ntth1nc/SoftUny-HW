using System;
namespace CompanyHierarchy
{
    public interface ICustomer : IEmployee
    {
        decimal NetPurchaseAmount { get; set; }
    }
}
