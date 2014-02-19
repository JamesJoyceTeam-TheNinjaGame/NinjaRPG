namespace NinjaWorld
{
    using System.Collections.Generic;

    public class Academy : Building
    {
        public static readonly List<Powers> ListOfPowers = new List<Powers>()
        {
            new Powers(AttackTypeEnum.MindAttack, "Diversion", 10, 80),
            new Powers(AttackTypeEnum.MindAttack, "Loops and Conditional Statements", 20, 80),
            new Powers(AttackTypeEnum.MindAttack, "Numeral Systems", 30, 90),
            new Powers(AttackTypeEnum.MindAttack, "Classes and Objects", 40, 80),
            new Powers(AttackTypeEnum.MindAttack, "Exception Handling", 50, 75),
            new Powers(AttackTypeEnum.MindAttack, "Class Hierarchies", 60, 75),
            new Powers(AttackTypeEnum.MindAttack, "Inheritance", 70, 80),
            new Powers(AttackTypeEnum.MindAttack, "Abstraction", 80, 80),
            new Powers(AttackTypeEnum.MindAttack, "Encapsulation", 90, 90),
            new Powers(AttackTypeEnum.MindAttack, "Polymorphism", 100, 90),
            new Powers(AttackTypeEnum.MindAttack, "Design Patterns", 110, 100)
        };

        public Academy(string name)
            : base(name)
        {            
        }

        public void OfferReward(Ninja ninja)
        {
            if (ninja.UpMentalLevel())
            {
                ninja.GetItem(ListOfPowers[ninja.MentalLevel]);
            }
        }
    }
}
