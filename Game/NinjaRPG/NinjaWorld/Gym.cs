namespace NinjaWorld
{
    using System.Collections.Generic;

    public class Gym : Building
    {
        public static readonly List<IAttack> ListOfPowers = new List<IAttack>()
        {
            new Power(AttackTypeEnum.ForceAttack, "Fist Fight", 10, 60),
            new Power(AttackTypeEnum.ForceAttack, "Boxing", 20, 90),
            new Power(AttackTypeEnum.ForceAttack, "Judo", 30, 80),
            new Power(AttackTypeEnum.ForceAttack, "Aikido", 40, 70),
            new Power(AttackTypeEnum.ForceAttack, "Taekwondo", 50, 80),
            new Power(AttackTypeEnum.ForceAttack, "Kung fu", 60, 75),
            new Power(AttackTypeEnum.ForceAttack, "Karate", 70, 80),
            new Power(AttackTypeEnum.ForceAttack, "Jujitsu", 80, 80),
            new Power(AttackTypeEnum.ForceAttack, "Muay Thai", 90, 85),
            new Power(AttackTypeEnum.ForceAttack, "Ninjutsu", 100, 90)
        };

        private const string BuildingName = "The Gym";

        public Gym()
            : base(BuildingName)
        {
        }

        public void WorkOut(Ninja ninja)
        {
            Evil enemy = new Assassin(ninja.MentalLevel + 1);

            Arena fight = new Arena(string.Format("Training {0}", ListOfPowers[ninja.MentalLevel]), FightRulesEnum.BrutalFight, ninja, enemy);

            fight.Fight();

            if (fight.IsNinjaWiner)
            {
                if (ninja.UpForceLevel())
                {
                    ninja.GetItem(ListOfPowers[ninja.ForceLevel - 1]);
                }
            }
            else
            {
                // ToDo: for Andrei: ??any string message for the looser
            }
        }
    }
}