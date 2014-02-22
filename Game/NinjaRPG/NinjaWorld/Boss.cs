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

        public void Heal(int hitPower)
        {
            this.CurrentEnergy += hitPower / BossHealPerHitRation;
        }

        public override int Attack(FightRulesEnum rules)
        {
            int bossAttack = base.Attack(rules);
            this.Heal(bossAttack);
            return bossAttack;
        }
    }
}
