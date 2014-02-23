namespace NinjaWorld
{
    using System;

    public abstract class Job
    {
        protected const int LowestBaseWage = 15;
        protected const int HighestBaseWage = 30;
        
        public Job()
        {
            this.Wage = this.JobLevel * new Random().Next(LowestBaseWage, HighestBaseWage + 1);
        }

        public FightRulesEnum JobFightRules { get; protected set; }

        public int Wage { get; protected set; }

        public string Possition { get; protected set; }

        public int JobLevel { get; protected set; }
    }
}
