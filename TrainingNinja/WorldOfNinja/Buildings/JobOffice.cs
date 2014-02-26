namespace WorldOfNinja.Buildings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Creatures;
    using Interfaces;

    public class JobOffice : WorldObject
    {
        private const string BuildingName = "Job Office";

        private static readonly Lazy<JobOffice> Lazy = new Lazy<JobOffice>(() => new JobOffice());

        private static readonly FightRules HeadWorkRules = new FightRules(1, 0.25);
        private static readonly FightRules BallancedWorkRules = new FightRules(0.25, 1);
        private static readonly FightRules PhysicalWorkRules = new FightRules(1, 1);
        private static readonly IList<IJob> Jobs = new List<IJob>()
        {
            new Job(HeadWorkRules, "Library Monitor", 1),
            new Job(HeadWorkRules, "Teaching Assistant", 3),
            new Job(HeadWorkRules, "Academy Assistant", 5),
            new Job(HeadWorkRules, "Campus Tech Support", 7),
            new Job(HeadWorkRules, "Campus Administration", 9),
            new Job(BallancedWorkRules, "Babysitter", 2),
            new Job(BallancedWorkRules, "Barista", 4),
            new Job(BallancedWorkRules, "Book Store Employee", 6),
            new Job(BallancedWorkRules, "Tour Guide", 8),
            new Job(BallancedWorkRules, "Student Production Assistant", 10),
            new Job(PhysicalWorkRules, "Fitness Center Employee", 1),
            new Job(PhysicalWorkRules, "Yoga Instructor", 3),
            new Job(PhysicalWorkRules, "Fitness Instructor", 5),
            new Job(PhysicalWorkRules, "Boxing Instructor", 8),
            new Job(PhysicalWorkRules, "Martial Art Instructor", 10)
        };

        private JobOffice()
            : base(BuildingName)
        {
        }

        public static JobOffice Instance
        {
            get { return Lazy.Value; }
        }

        public string FightResult { get; private set; }

        public void ApplyForJob(IHero hero, IJob chosenJob)
        {
            EvilCreature enemy = this.ChooseEnemy(chosenJob);

            Arena fight = new Arena(string.Format("Fighting for '{0}' position", chosenJob.Possition), chosenJob.JobFightRules, hero, enemy);

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
                this.RewardNinja(hero, chosenJob);
                this.FightResult = string.Format("Congratulation hero is now working at {0}", chosenJob.ToString());
            }
            else
            {
                this.FightResult = "The hero lost the battle and the job!";
            }
        }

        public IList<IJob> GenerateJobsFor(IHero hero)
        {
            return Jobs.Where(job =>
               (job.JobFightRules == PhysicalWorkRules &&
                job.JobLevel >= hero.ForceLevel - 1 &&
                job.JobLevel <= hero.ForceLevel + 1) ||
               (job.JobFightRules == HeadWorkRules &&
                job.JobLevel >= hero.MentalLevel - 1 &&
                job.JobLevel <= hero.MentalLevel + 1) ||
               (job.JobFightRules == BallancedWorkRules &&
                job.JobLevel >= ((hero.ForceLevel + hero.MentalLevel) / 2) - 1 &&
                job.JobLevel <= ((hero.ForceLevel + hero.MentalLevel) / 2) + 1))
                .OrderBy(rule => rule.JobFightRules)
                .ThenBy(wage => wage.Wage)
                .ToList();
        }

        private EvilCreature ChooseEnemy(IJob chosenJob)
        {
            if (chosenJob.JobFightRules.ForceAttackCoefficient > chosenJob.JobFightRules.MindAttackCoefficient)
            {
                return new Assassin(chosenJob.JobLevel);
            }
            else if (chosenJob.JobFightRules.ForceAttackCoefficient < chosenJob.JobFightRules.MindAttackCoefficient)
            {
                return new Bot(chosenJob.JobLevel);
            }
            else
            {
                return new Jedi(chosenJob.JobLevel);
            }
        }

        private void RewardNinja(IHero hero, IJob chosenJob)
        {
            int heroCashReward = chosenJob.Wage;
            hero.GetCash(heroCashReward);
        }
    }
}
