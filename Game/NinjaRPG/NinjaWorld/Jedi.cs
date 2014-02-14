namespace NinjaWorld
{
    using System;

    public class Jedi : Evil
    {
        private const int EnergyToMentalPowerRatio = 15;
        private const int MentalSuccessMax = 75;
        private const int MentalSuccessMin = 50;

        private const int EnergyToForcePowerRatio = 10;
        private const int ForceSuccessMax = 80;
        private const int ForceSuccessMin = 55;

        public Jedi(string name, int totalEnergy)
            : base(name, totalEnergy)
        {
            this.MentalPower = totalEnergy / EnergyToMentalPowerRatio;
            this.ForcePower = totalEnergy / EnergyToForcePowerRatio;
            this.MentalSuccess = new Random().Next(MentalSuccessMin, MentalSuccessMax + 1);
            this.ForceSuccess = new Random().Next(ForceSuccessMin, ForceSuccessMax + 1);
        }

        public int ForcePower { get; private set; }

        public int MentalPower { get; private set; }

        public int MentalSuccess { get; private set; }

        public int ForceSuccess { get; private set; }
    }
}