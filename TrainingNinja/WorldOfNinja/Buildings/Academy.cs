namespace WorldOfNinja.Buildings
{
    using System;
    using System.Collections.Generic;
    using Creatures;
    using Interfaces;
    using Item;

    public class Academy : TrainingCamps
    {
        public static readonly IList<ISkill> ListOfPowers = new List<ISkill>()
        {
            new Skill(PowerEnum.MentalPower, "Diversion", 10, 80),
            new Skill(PowerEnum.MentalPower, "Numeral Systems", 20, 80),
            new Skill(PowerEnum.MentalPower, "Classes and Objects", 30, 90),
            new Skill(PowerEnum.MentalPower, "Exception Handling", 40, 80),
            new Skill(PowerEnum.MentalPower, "Recursion", 50, 75),
            new Skill(PowerEnum.MentalPower, "Inheritance", 60, 75),
            new Skill(PowerEnum.MentalPower, "Abstraction", 70, 80),
            new Skill(PowerEnum.MentalPower, "Encapsulation", 80, 80),
            new Skill(PowerEnum.MentalPower, "Polymorphism", 90, 90),
            new Skill(PowerEnum.MentalPower, "Design Patterns", 100, 90)
        };

        private const string BuildingName = "Telerik Academy";

        private static readonly Lazy<Academy> Lazy = new Lazy<Academy>(() => new Academy());

        private static FightRules rules = new FightRules(1, 0.1);

        private Academy()
            : base(ListOfPowers, BuildingName, rules)
        {
        }

        public static Academy Instance
        {
            get { return Lazy.Value; }
        }

        protected override ICreature PickCreature(IHero hero)
        {
            return new Bot(hero.MentalLevel);
        }

        protected override void GiveReward(IHero hero)
        {
            hero.GetItem(ListOfPowers[hero.MentalLevel - 1]);
        }
    }
}