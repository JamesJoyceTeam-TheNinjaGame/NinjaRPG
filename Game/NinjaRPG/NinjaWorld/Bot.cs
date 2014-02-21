namespace NinjaWorld
{
    using System;

    public class Bot : Evil
    {
        private const int EnergyToMentalPowerRatio = 20;
        private const int MentalSuccessMax = 70;
        private const int MentalSuccessMin = 40;
        private const string MentalAttackName = "Brain Attack";

        private Powers mentalAttack;
        private int mentalPower;
        private int mentalSuccess;

        public Bot(int level)
            : base(RandomeEvilName.RandomName(RandomeEvilName.RobotNames), level)
        {
            this.mentalPower = this.TotalEnergy / EnergyToMentalPowerRatio;
            this.mentalSuccess = Randomizer.Rand.Next(MentalSuccessMin, MentalSuccessMax + 1);
            this.mentalAttack = new Powers(AttackTypeEnum.ForceAttack, MentalAttackName, this.mentalPower, this.mentalSuccess);
        }

        public override int Attack(FightRulesEnum rules)
        {
            return HitCalculator.DynamicDamageCalculator(mentalAttack, rules);
        }
    }
}