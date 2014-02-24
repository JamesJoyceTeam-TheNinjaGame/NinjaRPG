namespace NinjaWorld.Creatures
{
    using System;

    public abstract class Evil : Creature
    {
        private const int TotalEnergyToLevelRatio = 100; 

        public Evil(string name, int level)
            : base(name, level * TotalEnergyToLevelRatio)
        {
            this.Level = level;
        }

        public int Level { get; private set; }

        public abstract int Attack();
    }
}