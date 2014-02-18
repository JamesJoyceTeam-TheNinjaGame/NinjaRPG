namespace NinjaWorld
{
    using System;

    public class Boss : Jedi
    {
        private const string BossName = "The Boss";        
        private const int BoosHealPerHitRation = 10;

        public Boss()
            : base(BossName, Creatures.MaximalTotalEnergy)
        {
        }

        public int Heal(int hitPower)
        {
            return hitPower / BoosHealPerHitRation;
        }
    }
}
