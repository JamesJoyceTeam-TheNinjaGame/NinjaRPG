namespace WorldOfNinja
{
    public static class InitialEvilSettings
    {
        private const int DefaultEnergyToMentalPowerRatio = 15;
        private const int DefaultMentalSuccessMax = 75;
        private const int DefaultMentalSuccessMin = 50;
        private const string DefaultMentalAttackName = "Brain Attack";

        private const int DefaultEnergyToForcePowerRatio = 10;
        private const int DefaultForceSuccessMax = 80;
        private const int DefaultForceSuccessMin = 55;
        private const string DefaultForceAttackName = "Brutal Attack";

        private static int energyToMentalPowerRatio;
        private static int mentalSuccessMax;
        private static int mentalSuccessMin;
        private static string mentalAttackName;
          
        private static int energyToForcePowerRatio;
        private static int forceSuccessMax;
        private static int forceSuccessMin;
        private static string forceAttackName;

        public static int EnergyToMentalPowerRatio
        {
            get { return energyToMentalPowerRatio > 1 ? energyToMentalPowerRatio : DefaultEnergyToMentalPowerRatio; }
            set { energyToMentalPowerRatio = value; }
        }

        public static int MentalSuccessMax
        {
            get { return mentalSuccessMax > 1 ? mentalSuccessMax : DefaultMentalSuccessMax; }
            set { mentalSuccessMax = value; }
        }

        public static int MentalSuccessMin
        {
            get { return mentalSuccessMin > 1 ? mentalSuccessMin : DefaultMentalSuccessMin; }
            set { mentalSuccessMin = value; }
        }

        public static string MentalAttackName
        {
            get { return string.IsNullOrEmpty(mentalAttackName) ? mentalAttackName : DefaultMentalAttackName; }
            set { mentalAttackName = value; }
        }

        public static int EnergyToForcePowerRatio
        {
            get { return energyToForcePowerRatio > 1 ? energyToForcePowerRatio : DefaultEnergyToForcePowerRatio; }
            set { energyToForcePowerRatio = value; }
        }

        public static int ForceSuccessMax
        {
            get { return forceSuccessMax > 1 ? forceSuccessMax : DefaultForceSuccessMax; }
            set { forceSuccessMax = value; }
        }

        public static int ForceSuccessMin
        {
            get { return forceSuccessMin > 1 ? forceSuccessMin : DefaultForceSuccessMin; }
            set { forceSuccessMin = value; }
        }

        public static string ForceAttackName
        {
            get { return string.IsNullOrEmpty(forceAttackName) ? forceAttackName : DefaultForceAttackName; }
            set { forceAttackName = value; }
        }
    }
}
