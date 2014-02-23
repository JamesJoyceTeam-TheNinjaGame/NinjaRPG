namespace NinjaWorld
{
    using System;

    public abstract class Evil : Creature
    {
        private const int TotalEnergyToLevelRatio = 100; 

        public Evil(string name, int level)
            : base(name)
        {
            this.Level = level;
            this.TotalEnergy = level * TotalEnergyToLevelRatio;
        }

        public int Level { get; private set; }

        public abstract int Attack(FightRulesEnum rules);
    }
}