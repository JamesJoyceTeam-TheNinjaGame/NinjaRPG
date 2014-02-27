namespace WorldOfNinja.Creatures
{
    using Interfaces;

    public abstract class EvilCreature : Creature, ICreature
    {
        private const int TotalEnergyToLevelRatio = 100;
        
        public EvilCreature(string name, int level)
            : base(name, TotalEnergyToLevelRatio * level, level, level)
        {
            this.Level = level;
        }

        public int Level { get; private set; }

        public override abstract Hit Attack();
    }
}
