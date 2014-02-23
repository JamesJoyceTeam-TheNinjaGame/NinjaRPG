namespace NinjaWorld.Jobs
{
    using System.Collections.Generic;

    public class PhysicalJob : Job
    {
        private static readonly Dictionary<PhysicalWorkEnum, string> JobPositions = new Dictionary<PhysicalWorkEnum, string>()
        {            
            { PhysicalWorkEnum.FitnessCenterEmployee, "Fitness Center Employee" },
            { PhysicalWorkEnum.YogaInstructor, "Yoga Instructor" },
            { PhysicalWorkEnum.FitnessInstructor, "Fitness Instructor" },
            { PhysicalWorkEnum.BoxingInstructor, "Boxing Instructor" },
            { PhysicalWorkEnum.MartialArtInstructor, "Martial Art Instructor" }
        };

        public PhysicalJob(PhysicalWorkEnum job)
        {
            this.JobLevel = (int)job;
            this.Possition = JobPositions[job];
            this.JobFightRules = FightRulesEnum.BrutalFight;
        }
    }
}
