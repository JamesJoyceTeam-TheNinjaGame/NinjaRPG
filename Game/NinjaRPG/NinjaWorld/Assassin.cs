namespace NinjaWorld
{
    using System;

    public class Assassin : Evil
    {
        private const int EnergyToForcePowerRatio = 15;
        private const int ForceSuccessMax = 80;
        private const int ForceSuccessMin = 60;
        private const string ForceAttackName = "Brutal Attack";

        private Power forceAttack;
        private int forcePower;
        private int forceSuccess;

        public Assassin(int level)
            : base(RandomeEvilName.RandomName(RandomeEvilName.RobotNames), level)
        {
            this.forcePower = this.TotalEnergy / EnergyToForcePowerRatio;
            this.forceSuccess = Randomizer.Rand.Next(ForceSuccessMin, ForceSuccessMax + 1);
            this.forceAttack = new Power(AttackTypeEnum.ForceAttack, ForceAttackName, this.forcePower, this.forceSuccess);
        }

        public override int Attack(FightRulesEnum rules)
        {
            return HitCalculator.DynamicDamageCalculator(this.forceAttack, rules);
        }
    }
}
