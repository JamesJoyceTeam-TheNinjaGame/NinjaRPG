namespace WorldOfNinja.Creatures
{
    using Interfaces;
    using Item;

    public class Jedi : EvilCreature, ICreature
    {
        private ISkill mentalAttack;
        private int mentalPower;
        private int mentalSuccess;

        private ISkill forceAttack;
        private int forcePower;
        private int forceSuccess;

        public Jedi(int level)
            : base(RandomeEvilName.RandomName(RandomeEvilName.JediNames), level)
        {
            this.mentalPower = this.TotalEnergy / InitialEvilSettings.EnergyToMentalPowerRatio;
            this.forcePower = this.TotalEnergy / InitialEvilSettings.EnergyToForcePowerRatio;
            this.mentalSuccess = Randomizer.Rand.Next(InitialEvilSettings.MentalSuccessMin, InitialEvilSettings.MentalSuccessMax + 1);
            this.forceSuccess = Randomizer.Rand.Next(InitialEvilSettings.ForceSuccessMin, InitialEvilSettings.ForceSuccessMax + 1);
            this.forceAttack = new Skill(PowerEnum.ForcePower, InitialEvilSettings.ForceAttackName, this.forcePower, this.forceSuccess);
            this.mentalAttack = new Skill(PowerEnum.MentalPower, InitialEvilSettings.MentalAttackName, this.mentalPower, this.mentalSuccess);
        }

        public override Hit Attack()
        {
            if (Randomizer.Rand.Next(2) == 1)
            {
                return new Hit(HitCalculator.DynamicDamageCalculator(this.forceAttack), this.forceAttack.AttackType);
            }
            else
            {
                return new Hit(HitCalculator.DynamicDamageCalculator(this.mentalAttack), this.mentalAttack.AttackType);
            }
        }
    }
}
