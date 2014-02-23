namespace NinjaWorld
{
    using System.Collections.Generic;

    public class BalancedJob : Job
    {
        private static readonly Dictionary<BalancedJobEnum, string> JobPositions = new Dictionary<BalancedJobEnum, string>()
        {            
            { BalancedJobEnum.Babysitter, "Babysitter" },
            { BalancedJobEnum.Barista, "Barista" },
            { BalancedJobEnum.BookStoreEmployee, "Book Store Employee" },
            { BalancedJobEnum.TourGuide, "Tour Guide" },
            { BalancedJobEnum.StudentProductionAssistant, "Student Production Assistant" }
        };

        public BalancedJob(BalancedJobEnum job)
        {
            this.JobLevel = (int)job;
            this.Possition = JobPositions[job];
            this.JobFightRules = FightRulesEnum.BalancedFight;
        }
    }
}
