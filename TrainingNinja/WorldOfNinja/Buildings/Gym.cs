namespace WorldOfNinja.Buildings
{
    using System;
    using System.Collections.Generic;
    using Creatures;
    using Interfaces;
    using Item;

    public class Gym : TrainingCamps
    {
        public static readonly IList<ISkill> ListOfPowers = new List<ISkill>()
        {
            new Skill(PowerEnum.ForcePower, "Fist Fight", 10, 60),
            new Skill(PowerEnum.ForcePower, "Boxing", 20, 90),
            new Skill(PowerEnum.ForcePower, "Judo", 30, 80),
            new Skill(PowerEnum.ForcePower, "Aikido", 40, 70),
            new Skill(PowerEnum.ForcePower, "Taekwondo", 50, 80),
            new Skill(PowerEnum.ForcePower, "Kung fu", 60, 75),
            new Skill(PowerEnum.ForcePower, "Karate", 70, 80),
            new Skill(PowerEnum.ForcePower, "Jujitsu", 80, 80),
            new Skill(PowerEnum.ForcePower, "Muay Thai", 90, 85),
            new Skill(PowerEnum.ForcePower, "Ninjutsu", 100, 90)
        };

        private const string BuildingName = "World Class Gym";

        private static readonly Lazy<Gym> Lazy = new Lazy<Gym>(() => new Gym());

        private static FightRules rules = new FightRules(0.1, 1);

        private Gym()
            : base(ListOfPowers, BuildingName, rules)
        {
        }

        public static Gym Instance
        {
            get { return Lazy.Value; }
        }

        protected override ICreature PickCreature(IHero hero)
        {
            return new Assassin(hero.ForceLevel);
        }

        protected override void GiveReward(IHero hero)
        {
            hero.GetItem(ListOfPowers[hero.ForceLevel - 1]);
        }
    }
}