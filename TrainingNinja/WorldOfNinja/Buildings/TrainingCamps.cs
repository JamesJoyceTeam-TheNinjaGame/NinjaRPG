namespace WorldOfNinja.Buildings
{
    using System.Collections.Generic;
    using Interfaces;

    public abstract class TrainingCamps : WorldObject, IGameObject
    {
        private IList<ISkill> skills;
        private FightRules rules;

        public TrainingCamps(IList<ISkill> trainingSkills, string name, FightRules rules)
            : base(name)          
        {
            this.Skills = trainingSkills;
            this.rules = rules;
        }

        public string FightResult { get; private set; }

        public IList<ISkill> Skills
        {
            get
            {
                return new List<ISkill>(this.skills);
            }

            private set
            {
                this.skills = new List<ISkill>(value);
            }
        }

        public void Practice(IHero hero)
        {
            ICreature enemy = this.PickCreature(hero);

            Arena fight = new Arena(string.Format("Learning {0}"), this.rules, hero, enemy);

            // event?
            IUsable item = hero.ListOfFightingSkills[0];
            do
            {
                // IUsable item = selected Item!
                item = hero.ListOfFightingSkills[0];
            }
            while (fight.Fight(item));
            //// event end

            if (fight.IsHeroWinner)
            {
                if (hero.UpMentalLevel())
                {
                    this.GiveReward(hero);
                    this.FightResult = "You are winner!";
                }
            }
            else
            {
                this.FightResult = "You are looser!";
            }
        }

        protected abstract ICreature PickCreature(IHero hero);

        protected abstract void GiveReward(IHero hero);
    }
}
