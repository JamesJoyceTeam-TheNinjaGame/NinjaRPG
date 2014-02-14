namespace NinjaWorld
{
    public class Energizers : Items, ICommercial
    {
        private const int PricePerHeal = 1;
        
        public Energizers(EnergizerEnum energizer, string name)
            : base(name)
        {
            this.Energizer = energizer;
            this.HealingPoints = (int)this.Energizer;
            this.Price = this.HealingPoints * PricePerHeal;
        }

        public EnergizerEnum Energizer { get; private set; }

        public int HealingPoints { get; private set; }

        public int Price { get; set; }
    }
}