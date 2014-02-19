namespace NinjaWorld
{
    using System.Collections.Generic;

    public class Gym : Building
    {
        public static readonly List<Powers> ListOfPowers = new List<Powers>()
        {
            new Powers(AttackTypeEnum.ForceAttack, "Fist Fight", 10, 60),
            new Powers(AttackTypeEnum.ForceAttack, "Boxing", 20, 90),
            new Powers(AttackTypeEnum.ForceAttack, "Judo", 30, 80),
            new Powers(AttackTypeEnum.ForceAttack, "Aikido", 40, 70),
            new Powers(AttackTypeEnum.ForceAttack, "Taekwondo", 50, 80),
            new Powers(AttackTypeEnum.ForceAttack, "Krav Maga", 60, 75),
            new Powers(AttackTypeEnum.ForceAttack, "Kung fu", 70, 80),
            new Powers(AttackTypeEnum.ForceAttack, "Karate", 80, 80),
            new Powers(AttackTypeEnum.ForceAttack, "Jujitsu", 90, 85),
            new Powers(AttackTypeEnum.ForceAttack, "Muay Thai", 100, 90),
            new Powers(AttackTypeEnum.ForceAttack, "Ninjutsu", 110, 95)
        };

        public Gym(string name)
            : base(name)
        {
        }

        public void OfferReward(Ninja ninja)
        {
            if (ninja.UpForceLevel())
            {
                ninja.GetItem(ListOfPowers[ninja.ForceLevel]);
            }
        }
    }
}
