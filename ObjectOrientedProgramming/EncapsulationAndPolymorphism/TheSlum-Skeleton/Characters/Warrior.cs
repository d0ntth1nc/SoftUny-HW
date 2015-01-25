using System.Collections.Generic;
using System.Linq;
using TheSlum.Interfaces;

namespace TheSlum.Characters
{
    public class Warrior : Character, IAttack
    {
        public Warrior(string id, int x, int y, Team team,
            int healthPoints = 200, int defensePoints = 100, int range = 2, int attackPoints = 150)
            : base(id, x, y, healthPoints, defensePoints, team, range)
        {
            this.AttackPoints = attackPoints;
        }

        public Warrior(string id, int x, int y, Team team)
            : base(id, x, y, 200, 100, team, 2)
        {
            this.AttackPoints = 150;
        }

        public int AttackPoints { get; set; }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            return targetsList
                .Where(x => x.Team != this.Team && x.IsAlive)
                .FirstOrDefault();
        }

        public override void AddToInventory(Item item)
        {
            this.ApplyItemEffects(item);
            this.Inventory.Add(item);
        }

        public override void RemoveFromInventory(Item item)
        {
            this.RemoveItemEffects(item);
            this.Inventory.Remove(item);
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(", Attack: {0}", this.AttackPoints);
        }

        protected override void ApplyItemEffects(Item item)
        {
            base.ApplyItemEffects(item);
            this.AttackPoints += item.AttackEffect;
        }

        protected override void RemoveItemEffects(Item item)
        {
            base.RemoveItemEffects(item);
            this.AttackPoints -= item.AttackEffect;
        }
    }
}