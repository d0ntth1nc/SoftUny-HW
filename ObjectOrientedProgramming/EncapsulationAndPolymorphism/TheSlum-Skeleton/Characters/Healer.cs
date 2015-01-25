using System;
using System.Collections.Generic;
using System.Linq;
using TheSlum.Interfaces;

namespace TheSlum.Characters
{
    public class Healer : Character, IHeal
    {
        public Healer(string id, int x, int y, Team team,
            int healthPoints = 75, int defensePoints = 50, int range = 6, int healingPoints = 60)
            : base(id, x, y, healthPoints, defensePoints, team, range)
        {
            this.HealingPoints = healingPoints;
        }

        public Healer(string id, int x, int y, Team team)
            : base(id, x, y, 75, 50, team, 6)
        {
            this.HealingPoints = 60;
        }

        public int HealingPoints { get; set; }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            return targetsList
                .Where(x => x != this &&x.Team == this.Team && x.IsAlive)
                .OrderBy(x => x.HealthPoints).FirstOrDefault();
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
            return base.ToString() + string.Format(", Healing: {0}", this.HealingPoints);
        }

        protected override void ApplyItemEffects(Item item)
        {
            base.ApplyItemEffects(item);
            this.HealingPoints += item.AttackEffect;
        }

        protected override void RemoveItemEffects(Item item)
        {
            base.RemoveItemEffects(item);
            this.HealingPoints -= item.AttackEffect;
        }
    }
}
