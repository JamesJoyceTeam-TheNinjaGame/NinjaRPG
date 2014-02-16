namespace NinjaWorld
{
    using System;

    public class Boss : Jedi
    {
        private const string BossName = "The Boss";        
        private const int BossHealPerHitRation = 10;
        private const int BossLevel = 50;

        public Boss()
            : base(BossLevel)
        {
        }

        public int Heal(int hitPower)
        {
            return hitPower / BossHealPerHitRation;
        }
    }
}
