namespace WorldOfNinja.Creatures
{
    using Interfaces;
    using Item;

    public class Assassin : EvilCreature, ICreature
    {
        private ISkill forceAttack;
        private int forcePower;
        private int forceSuccess;

        public Assassin(int level)
            : base(RandomeEvilName.RandomName(RandomeEvilName.AssasinNames), level)
        {
            this.forcePower = this.TotalEnergy / InitialEvilSettings.EnergyToForcePowerRatio;
            this.forceSuccess = Randomizer.Rand.Next(InitialEvilSettings.ForceSuccessMin, InitialEvilSettings.ForceSuccessMax + 1);
            this.forceAttack = new Skill(PowerEnum.ForcePower, InitialEvilSettings.ForceAttackName, this.forcePower, this.forceSuccess);
        }

        public override Hit Attack()
        {
            return new Hit(HitCalculator.DynamicDamageCalculator(this.forceAttack), this.forceAttack.AttackType);
        }
    }
}