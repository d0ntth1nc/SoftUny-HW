using System;

namespace LaptopShop
{
    class Battery
    {
        public string Type { get; private set; }
        public int Cells { get; private set; }
        public int Capacity { get; private set; }
        public int Life { get; private set; }

        public Battery(string type, int cells, int capacity, int life)
        {
            if (String.IsNullOrEmpty(type) || cells <= 0 || capacity <= 0 || life <= 0)
            {
                throw new ArgumentException("Please enter non-empty values!");
            }
            this.Type = type;
            this.Cells = cells;
            this.Capacity = capacity;
            this.Life = life;
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}-cells, {2} mAh", this.Type, this.Cells, this.Capacity);
        }
    }
}
