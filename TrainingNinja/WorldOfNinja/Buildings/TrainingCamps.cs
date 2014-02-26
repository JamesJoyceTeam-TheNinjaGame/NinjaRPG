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

        public Arena Practice(IHero hero)
        {
            ICreature enemy = this.PickCreature(hero);

            return new Arena(string.Format("Learning {0}"), this.rules, hero, enemy);
        }

        protected abstract ICreature PickCreature(IHero hero);

        public abstract void GiveReward(IHero hero);
    }
}
