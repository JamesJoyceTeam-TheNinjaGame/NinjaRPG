namespace NinjaWorld
{
    using System;

    public abstract class Evil : Creatures
    {
        private const int TotalEnergyToLevelRation = 100; 

        public Evil(string name, int level)
            : base(name, level * TotalEnergyToLevelRation)
        {
            this.Level = level;
        }

        protected int Level { get; private set; }    
    }
}