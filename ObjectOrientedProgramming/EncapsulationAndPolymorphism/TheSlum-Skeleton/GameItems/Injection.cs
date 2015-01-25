
namespace TheSlum.GameItems
{
    public class Injection : Bonus
    {
        public Injection(string id)
            : base(id, 200, 0, 0)
        {
            this.Timeout = 3;
            this.Countdown = 3;
        }
    }
}
