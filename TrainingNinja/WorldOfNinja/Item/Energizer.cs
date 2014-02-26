namespace WorldOfNinja.Item
{
    using Interfaces;

    public class Energizer : UsableItem, ICommercialItem, IEnergizer
    {
        private const int PricePerHeal = 1;
        private int healingPoints;

        private int price;

        public Energizer(int healingPoints, string name)
            : base(name)
        {
            this.HealingPoints = healingPoints;
            this.Price = this.HealingPoints * PricePerHeal;
        }

        public int HealingPoints 
        { 
            get 
            { 
                return this.healingPoints; 
            } 
            
            private set 
            {
                if (value < 1)
                {
                    throw new ImproperlyDefinedItemException("Healing points must be positive integer");
                }

                this.healingPoints = value;
            }
        }

        public int Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value < 0)
                {
                    throw new ImproperlyDefinedItemException("Price could be only positive integer");
                }

                this.price = value;
            }
        }

        public object Clone()
        {
            return new Energizer(this.healingPoints, this.Name);
        }
    }
}
