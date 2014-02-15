namespace NinjaWorld
{
    public class Recreations : Items, ICommercial
    {
        private const int IntlPricePerEnergy = 1;
        private const int PriceInflation = 1;

        private const int IntlEnergy = 5;
        private const int EnergyGrowStep = 5;

        private static int currentEnergy = IntlEnergy;
        private static int currentPricePerLife = IntlPricePerEnergy;
        
        public Recreations(string name)
            : base(name)
        {
            this.Price = currentEnergy * currentPricePerLife;
            this.EnergyUpgrade = currentEnergy;
            currentEnergy += EnergyGrowStep;
            currentPricePerLife += PriceInflation;
        }

        public int EnergyUpgrade { get; private set; }

        public int Price { get; set; }
    }
}
