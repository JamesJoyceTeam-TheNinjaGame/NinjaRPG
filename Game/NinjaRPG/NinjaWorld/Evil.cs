namespace NinjaWorld
{
    using System;

    public abstract class Evil : Creatures
    {
        // Fixed form 10 to 100
        private const int TotalEnergyToLevelRation = 100; 

        public Evil(string name, int level)
            : base(name)
        {
            this.Level = level;
            this.TotalEnergy = level * TotalEnergyToLevelRation;
        }

        protected int Level { get; private set; }

        public abstract int Attack(FightRulesEnum rules);
    }
}