namespace WorldOfNinja.Item
{
    using Interfaces;

    public class Recreation : UsableItem, ICommercialItem, IEnergyExpandable
    {
        private const int IntlPricePerEnergy = 1;
        private const int PriceInflation = 1;

        private const int IntlEnergy = 5;
        private const int EnergyGrowStep = 5;

        private static int currentEnergy = IntlEnergy;
        private static int currentPricePerEnergy = IntlPricePerEnergy;

        public Recreation(string name)
            : base(name)
        {
            this.Price = currentEnergy * currentPricePerEnergy;
            this.UpgradeTotalEnergy = currentEnergy;
            currentEnergy += EnergyGrowStep;
            currentPricePerEnergy += PriceInflation;
        }

        public int UpgradeTotalEnergy { get; private set; }

        public int Price { get; set; }

        public object Clone()
        {
            return new Recreation(this.Name);
        }
    }
}
