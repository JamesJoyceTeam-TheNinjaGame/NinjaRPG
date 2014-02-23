namespace NinjaWorld.Jobs
{
    using System.Collections.Generic;

    public class MentalJob : Job
    {
        private static readonly Dictionary<HeadworkEnum, string> JobPositions = new Dictionary<HeadworkEnum, string>()
        {            
            { HeadworkEnum.LibraryMonitor, "Library Monitor" },
            { HeadworkEnum.TeachingAssistant, "Teaching Assistant" },
            { HeadworkEnum.AcademyAssistant, "Academy Assistant" },
            { HeadworkEnum.CampusTechSupport, "Campus Tech Support" },
            { HeadworkEnum.CampusAdministration, "Campus Administration" }
        };

       public MentalJob(HeadworkEnum job)
        {
            this.JobLevel = (int)job;
            this.Possition = JobPositions[job];
            this.JobFightRules = FightRulesEnum.MentalFight;
        }
    }
}
