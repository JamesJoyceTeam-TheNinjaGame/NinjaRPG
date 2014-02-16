﻿namespace NinjaWorld
{
    using System;

    public class Bot : Evil
    {
        private const int EnergyToMentalPowerRatio = 20;
        private const int MentalSuccessMax = 70;
        private const int MentalSuccessMin = 40;

        public Bot(int level)
            : base(RandomeEvilName.RandomName(RandomeEvilName.RobotNames), level)
        {
            this.MentalPower = this.TotalEnergy / EnergyToMentalPowerRatio;
            this.MentalSuccess = new Random().Next(MentalSuccessMin, MentalSuccessMax + 1);
        }

        public int MentalPower { get; private set; }

        public int MentalSuccess { get; private set; }
    }
}