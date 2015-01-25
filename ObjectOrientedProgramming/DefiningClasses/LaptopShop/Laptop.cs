using System;
using System.Text;

namespace LaptopShop
{
    class Laptop
    {
        Battery battery;
        string model;
        string manufacturer;
        string processor;
        string ram;
        string graphicCard;
        string hdd;
        string screen;
        decimal price;

        public Laptop(string model, decimal price, string manufacturer = null,
            string processor = null, string ram = null, string graphicCard = null,
            string hdd = null, string screen = null, Battery battery = null)
        {
            this.Model = model;
            this.Price = price;
            this.Manufacturer = manufacturer;
            this.Processor = processor;
            this.Ram = ram;
            this.GraphicCard = graphicCard;
            this.Hdd = hdd;
            this.battery = battery;
        }

        public string Model
        {
            get { return this.model; }
            set
            {
                CheckInput(value, "Model");
                this.model = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                CheckInput(value, "Price");
                this.price = value;
            }
        }

        public string Manufacturer
        {
            get { return this.manufacturer; }
            set
            {
                CheckInput(value, "Manufacturer");
                this.manufacturer = value;
            }
        }
        
        public string Processor
        {
            get { return this.processor; }
            set
            {
                CheckInput(value, "Processor");
                this.processor = value;
            }
        }

        public string Ram
        {
            get { return this.ram; }
            set
            {
                CheckInput(value, "RAM");
                this.ram = value;
            }
        }

        public string GraphicCard
        {
            get { return this.graphicCard; }
            set
            {
                CheckInput(value, "GraphicCard");
                this.graphicCard = value;
            }
        }

        public string Hdd
        {
            get { return this.hdd; }
            set 
            {
                CheckInput(value, "HDD");
                this.hdd = value;
            }
        }

        public string Screen
        {
            get { return this.screen; }
            set
            {
                CheckInput(value, "Screen");
                this.screen = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("Model: {0}\n", this.Model);
            sb.AppendFormat("Manufacturer: {0}\n", this.Manufacturer);
            sb.AppendFormat("Processor: {0}\n", this.Processor);
            sb.AppendFormat("RAM: {0}\n", this.Ram);
            sb.AppendFormat("Graphic card: {0}\n", this.GraphicCard);
            sb.AppendFormat("HDD: {0}\n", this.Hdd);
            sb.AppendFormat("Screen: {0}\n", this.Screen);
            if (this.battery != null)
            {
                sb.AppendFormat("Battery: {0}\n", this.battery);
                sb.AppendFormat("Battery life: {0} hours\n", this.battery.Life);
            }
            sb.AppendFormat("Price: {0} lv\n", this.Price);

            return sb.ToString();
        }

        private void CheckInput(object value, string propName)
        {
            if (value != null)
            {
                if (value.GetType() == typeof(String))
                {
                    if (String.IsNullOrEmpty((string)value))
                    {
                        throw new ArgumentException(string.Format("{0} cannot be null or empty!", propName));
                    }
                }
                else
                {
                    if (Convert.ToDecimal(value) < 0)
                    {
                        throw new ArgumentOutOfRangeException(string.Format("{0} cannot be negative number!", propName));
                    }
                }
            }
        }
    }
}
