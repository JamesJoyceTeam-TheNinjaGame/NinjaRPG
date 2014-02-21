namespace NinjaWorld
{
    using System;

    public abstract class Evil : Creatures
    {
        private const int TotalEnergyToLevelRation = 10; 

        public Evil(string name, int level)
            : base(name)
        {
            this.Level = level;
            this.TotalEnergy = level * TotalEnergyToLevelRation;
        }

        protected int Level { get; private set; }    
    }
}