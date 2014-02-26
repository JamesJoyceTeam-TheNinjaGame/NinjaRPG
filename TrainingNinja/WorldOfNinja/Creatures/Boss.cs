namespace WorldOfNinja.Creatures
{
    using Interfaces;

    public class Boss : Jedi, IRegenerable
    {
        private const string BossName = "The Boss";
        private const int BossHealPerHitRation = 10;
        private const int BossLevel = 50;

        public Boss()
            : base(BossLevel)
        { 
        }

        public override Hit Attack()
        {
            Hit damage = base.Attack();
            this.IncreaseCurrentEnergy(damage.Power / BossHealPerHitRation);
            return damage;
        }

        public void IncreaseCurrentEnergy(int energy)
        {
            this.CurrentEnergy += energy;
        }
    }
}
