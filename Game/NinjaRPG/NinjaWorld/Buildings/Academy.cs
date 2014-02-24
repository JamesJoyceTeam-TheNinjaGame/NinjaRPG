// ToDo: for Ivan Tochev: Check if its better to be singleton.

namespace NinjaWorld.Buildings
{
    using System.Collections.Generic;
    using NinjaWorld.Creatures;
    using NinjaWorld.Items;

    /// <summary>
    /// The building where you practice and get Mental Powers
    /// </summary>
    public class Academy : Building
    {
        public static readonly List<IAttack> ListOfPowers = new List<IAttack>()
        {
            new Power(AttackTypeEnum.MindAttack, "Numeral Systems", 20, 80),
            new Power(AttackTypeEnum.MindAttack, "Classes and Objects", 30, 90),
            new Power(AttackTypeEnum.MindAttack, "Exception Handling", 40, 80),
            new Power(AttackTypeEnum.MindAttack, "Recursion", 50, 75),
            new Power(AttackTypeEnum.MindAttack, "Inheritance", 60, 75),
            new Power(AttackTypeEnum.MindAttack, "Abstraction", 70, 80),
            new Power(AttackTypeEnum.MindAttack, "Encapsulation", 80, 80),
            new Power(AttackTypeEnum.MindAttack, "Polymorphism", 90, 90),
            new Power(AttackTypeEnum.MindAttack, "Design Patterns", 100, 90)
        };

        private const string BuildingName = "Telerik Academy";

        /// <summary>
        /// Initializes a new instance of the <see cref="Academy"/> class with constant name
        /// </summary>
        public Academy()
            : base(BuildingName)
        {
        }

        /// <summary>
        /// Sending ninja to fight
        /// </summary>
        /// <param name="ninja">ninja's instance</param>
        public void Study(Ninja ninja)
        {
            Evil enemy = new Bot(ninja.MentalLevel + 1);

            Arena fight = new Arena(string.Format("Learning {0}", ListOfPowers[ninja.MentalLevel]), FightRulesEnum.MentalFight, ninja, enemy);

            fight.Fight();

            if (fight.IsNinjaWiner)
            {
                if (ninja.UpMentalLevel())
                {
                    ninja.GetItem(ListOfPowers[ninja.MentalLevel - 2]);
                }
            }
            else
            {
                // ToDo: for Andrei: ??any string message for the looser
            }
        }
    }
}