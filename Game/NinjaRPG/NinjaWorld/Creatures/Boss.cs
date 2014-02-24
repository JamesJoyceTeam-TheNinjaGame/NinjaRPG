namespace NinjaWorld.Creatures
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

        public void Regenerate(int hitPower)
        {
            this.CurrentEnergy += hitPower / BossHealPerHitRation;
        }

        public override int Attack()
        {
            int damage = base.Attack();
            this.Regenerate(damage);
            return damage;
        }
    }
}