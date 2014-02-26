namespace WorldOfNinja.Creatures
{
    using Interfaces;
    using Item;

    public class Bot : EvilCreature, ICreature
    {
        private ISkill mentalAttack;
        private int mentalPower;
        private int mentalSuccess;

        public Bot(int level)
            : base(RandomeEvilName.RandomName(RandomeEvilName.RobotNames), level)
        {
            this.mentalPower = this.TotalEnergy / InitialEvilSettings.EnergyToMentalPowerRatio;
            this.mentalSuccess = Randomizer.Rand.Next(InitialEvilSettings.MentalSuccessMin, InitialEvilSettings.MentalSuccessMax + 1);
            this.mentalAttack = new Skill(PowerEnum.MentalPower, InitialEvilSettings.MentalAttackName, this.mentalPower, this.mentalSuccess);
        }

        public override Hit Attack()
        {
            return new Hit(HitCalculator.DynamicDamageCalculator(this.mentalAttack), this.mentalAttack.AttackType);
        }
    }
}