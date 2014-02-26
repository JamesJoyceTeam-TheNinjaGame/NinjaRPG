namespace WorldOfNinja
{
    using System;
    using Interfaces;

    /// <summary>
    /// Calculates the damage power of ninja and enemy hits
    /// </summary>
    public static class HitCalculator
    {
        private const int HitPrecision = 10;

        /// <summary>
        /// Calculate and returns the damage to be removed
        /// </summary>
        /// <param name="power">attack power</param>
        /// <param name="rules">attack success</param>
        /// <returns>damage to be removed from hitted enemy</returns>
        public static int DynamicDamageCalculator(ISkill power)
        {
            int powerNumerator = new int();
            for (int i = 0; i < HitPrecision; i++)
            {
                if (Randomizer.Rand.Next(0, 101) <= power.SuccessRate)
                {
                    powerNumerator += power.AttackPower;
                }
            }
            
            return powerNumerator / HitPrecision;
        }
    }
}