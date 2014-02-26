namespace WorldOfNinja
{
    using System;
    using Interfaces;

    public class Job : WorldObject, IGameObject, IJob
    {
        protected const int LowestBaseWage = 15;
        protected const int HighestBaseWage = 30;

        public Job(FightRules fightRule, string jobPosition, int jobLevel)
            : base(jobPosition)
        {
            this.JobLevel = jobLevel;
            this.JobFightRules = fightRule;
            this.Possition = jobPosition;
            this.Wage = this.JobLevel * new Random().Next(LowestBaseWage, HighestBaseWage + 1);
        }

        public FightRules JobFightRules { get; private set; }
               
        public int Wage { get; private set; }

        public string Possition { get; private set; }

        public int JobLevel { get; private set; }

        public override string ToString()
        {
            return string.Format("job position {0} at wage ${1}", this.Possition, this.Wage);
        }
    }
}
