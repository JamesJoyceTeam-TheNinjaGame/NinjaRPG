namespace NinjaWorld
{
    using System;

    public class Jedi : Evil
    {
        private const int EnergyToMentalPowerRatio = 15;
        private const int MentalSuccessMax = 75;
        private const int MentalSuccessMin = 50;
        private const string MentalAttackName = "Brain Attack";

        private const int EnergyToForcePowerRatio = 10;
        private const int ForceSuccessMax = 80;
        private const int ForceSuccessMin = 55;
        private const string ForceAttackName = "Brutal Attack";

        private Powers mentalAttack;
        private int mentalPower;
        private int mentalSuccess;

        private Powers forceAttack;
        private int forcePower;
        private int forceSuccess;

        public Jedi(int level)
            : base(RandomeEvilName.RandomName(RandomeEvilName.JediNames), level)
        {
            this.mentalPower = this.TotalEnergy / EnergyToMentalPowerRatio;
            this.forcePower = this.TotalEnergy / EnergyToForcePowerRatio;
            this.mentalSuccess = Randomizer.Rand.Next(MentalSuccessMin, MentalSuccessMax + 1);
            this.forceSuccess = Randomizer.Rand.Next(ForceSuccessMin, ForceSuccessMax + 1);
            this.forceAttack = new Powers(AttackTypeEnum.ForceAttack, ForceAttackName, this.forcePower, this.forceSuccess);
            this.mentalAttack = new Powers(AttackTypeEnum.ForceAttack, MentalAttackName, this.mentalPower, this.mentalSuccess);
        }

        public override int Attack(FightRulesEnum rules)
        {
            if (Randomizer.Rand.Next(2) == 1)
            {
                return HitCalculator.DynamicDamageCalculator(forceAttack, rules);
            }
            else
            {
                return HitCalculator.DynamicDamageCalculator(mentalAttack, rules);
            }
        }
    }
}