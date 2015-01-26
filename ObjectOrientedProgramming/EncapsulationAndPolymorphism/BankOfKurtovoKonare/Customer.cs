
namespace BankOfKurtovoKonare
{
    public class Customer : BankOfKurtovoKonare.ICustomer
    {
        public Customer(string name, CustomerType type)
        {
            this.Name = name;
            this.Type = type;
        }

        public string Name { get; set; }
        public CustomerType Type { get; set; }
    }
}
