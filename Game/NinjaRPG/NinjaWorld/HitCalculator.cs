namespace NinjaWorld
{
    using System;

    /// <summary>
    /// Calculates the damage power of ninja and enemy hits
    /// </summary>
    public static class HitCalculator
    {
        private const int HitPrecision = 10;
        private const int WrontHitPenaltyDenominator = 4;

        /// <summary>
        /// Calculate and returns the damage to be removed
        /// </summary>
        /// <param name="power">attack power</param>
        /// <param name="rules">attack success</param>
        /// <returns>damage to be removed from hitted enemy</returns>
        public static int DynamicDamageCalculator(IAttack power, FightRulesEnum rules)
        {
            int powerNumerator = new int();
            for (int i = 0; i < HitPrecision; i++)
            {
                if (Randomizer.Rand.Next(0, 101) <= power.SuccessRate)
                {
                    powerNumerator += power.AttackPower;
                }
            }
            
            if ((power.AttackType == AttackTypeEnum.ForceAttack && rules == FightRulesEnum.MentalFight) ||
            (power.AttackType == AttackTypeEnum.MindAttack && rules == FightRulesEnum.BrutalFight))
            {
                return powerNumerator / (HitPrecision * WrontHitPenaltyDenominator);
            }

            return powerNumerator / HitPrecision;
        }
    }
}