namespace NinjaWorld
{
    public class Energizer : Item, ICommercial, IItem
    {
        private const int PricePerHeal = 1;
        private EnergizerEnum energizer;

        private int price;

        public Energizer(EnergizerEnum energizingItem, string name)
            : base(name)
        {
            this.energizer = energizingItem;
            this.HealingPoints = (int)this.energizer;
            this.Price = this.HealingPoints * PricePerHeal;
        }

        public int HealingPoints { get; private set; }

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
            return new Energizer(this.energizer, this.Name);
        }
    }
}