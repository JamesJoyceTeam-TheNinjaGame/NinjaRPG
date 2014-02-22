// ToDo: for Ivan Tochev: Check if its better to be singleton.

namespace NinjaWorld
{
    using System.Collections.Generic;

    /// <summary>
    /// The building where you practice and get Mental Powers
    /// </summary>
    public class Academy : Building
    {      
        public static readonly List<Powers> ListOfPowers = new List<Powers>()
        {
            new Powers(AttackTypeEnum.MindAttack, "Diversion", 10, 80),
            new Powers(AttackTypeEnum.MindAttack, "Numeral Systems", 20, 80),
            new Powers(AttackTypeEnum.MindAttack, "Classes and Objects", 30, 90),
            new Powers(AttackTypeEnum.MindAttack, "Exception Handling", 40, 80),
            new Powers(AttackTypeEnum.MindAttack, "Recursion", 50, 75),
            new Powers(AttackTypeEnum.MindAttack, "Inheritance", 60, 75),
            new Powers(AttackTypeEnum.MindAttack, "Abstraction", 70, 80),
            new Powers(AttackTypeEnum.MindAttack, "Encapsulation", 80, 80),
            new Powers(AttackTypeEnum.MindAttack, "Polymorphism", 90, 90),
            new Powers(AttackTypeEnum.MindAttack, "Design Patterns", 100, 90)
        };

        private const string ArenaName = "Telerik Academy";

        /// <summary>
        /// Initializes a new instance of the <see cref="Academy"/> class with constant name
        /// </summary>
        public Academy(string name)
            : base(name)
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
                ninja.UpMentalLevel();
            }
            else
            {
                // ToDo: for Andrei: ??any string message for the looser
            }
        }
    }
}