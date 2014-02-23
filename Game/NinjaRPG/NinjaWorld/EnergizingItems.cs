namespace NinjaWorld
{
    public class EnergizingItems : Items, ICommercial, IItem
    {
        private const int PricePerHeal = 1;

        public EnergizingItems(EnergizerEnum energizer, string name)
            : base(name)
        {
            this.Energizer = energizer;
            this.HealingPoints = (int)this.Energizer;
            this.Price = this.HealingPoints * PricePerHeal;
        }

        public EnergizerEnum Energizer { get; private set; }

        public int HealingPoints { get; private set; }

        public int Price { get; set; }

        public object Clone()
        {
            return new EnergizingItems(this.Energizer, (string)this.Name.Clone());
        }
    }
}