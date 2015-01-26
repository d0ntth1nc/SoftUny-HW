using System;
namespace BankOfKurtovoKonare
{
    interface ICustomer
    {
        string Name { get; set; }
        CustomerType Type { get; set; }
    }
}
