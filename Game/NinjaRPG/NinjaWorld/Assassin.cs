namespace NinjaWorld
{
    using System;

    public class Assassin : Evil
    {
        private const int EnergyToForcePowerRatio = 15;
        private const int ForceSuccessMax = 80;
        private const int ForceSuccessMin = 60;

        public Assassin(string name, int totalEnergy)
            : base(name, totalEnergy)
        {
            this.ForcePower = totalEnergy / EnergyToForcePowerRatio;
            this.ForceSuccess = new Random().Next(ForceSuccessMin, ForceSuccessMax + 1);
        }

        public int ForcePower { get; private set; }

        public int ForceSuccess { get; private set; }
    }
}
