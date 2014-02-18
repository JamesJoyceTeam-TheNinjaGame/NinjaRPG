namespace NinjaWorld
{
    using System;
    using System.Collections.Generic;

    public class JobOffice : Building
    {
        public JobOffice(string name)
            : base(name)
        {
        }

        public void ApplyForJob(Ninja ninja, Job chosenJob)
        {
            Evil enemy = this.ChooseEnemy(chosenJob);
            
            Arena fight = new Arena(string.Format("Fighting for '{0}' position", chosenJob.Possition), chosenJob.JobFihtRules, enemy);

            fight.Fight();

            if (fight.IsNinjaWiner)
            {                
                this.RewardNinja(ninja, chosenJob);
            }
            else
            {
                // ToDo: ??any string message for the looser
            }
        }

        public List<Job> GenerateJobsFor(Ninja ninja)
        {
            List<Job> listOfJobs = new List<Job>();

            var physicalJobNames = PhysicalWorkEnum.GetNames(typeof(PhysicalWorkEnum));
            foreach (var jobName in physicalJobNames)
            {
                PhysicalWorkEnum job = (PhysicalWorkEnum)Enum.Parse(typeof(PhysicalWorkEnum), jobName);
                if ((int)job >= (ninja.ForceLevel - 1) &&
                    (int)job <= (ninja.ForceLevel + 1))
                {
                    listOfJobs.Add(new PhysicalJob(job));
                }
            }

            var headworkNames = HeadworkEnum.GetNames(typeof(HeadworkEnum));
            foreach (var jobName in headworkNames)
            {
                HeadworkEnum job = (HeadworkEnum)Enum.Parse(typeof(HeadworkEnum), jobName);
                if ((int)job >= (ninja.MentalLevel - 1) &&
                    (int)job <= (ninja.MentalLevel + 1))
                {
                    listOfJobs.Add(new MentalJob(job));
                }
            }

            var balancedJobNames = BalancedJobEnum.GetNames(typeof(BalancedJobEnum));
            foreach (var jobName in balancedJobNames)
            {
                BalancedJobEnum job = (BalancedJobEnum)Enum.Parse(typeof(BalancedJobEnum), jobName);
                if ((int)job >= (((ninja.ForceLevel + ninja.MentalLevel) / 2) - 1) &&
                    (int)job <= (((ninja.ForceLevel + ninja.MentalLevel) / 2) + 1))
                {
                    listOfJobs.Add(new BalancedJob(job));
                }
            }

            return listOfJobs;
        }

        private Evil ChooseEnemy(Job chosenJob)
        {
            if (chosenJob.JobFihtRules == FightRulesEnum.BrutalFight)
            {
                return new Assassin(chosenJob.JobLevel);
            }
            else if (chosenJob.JobFihtRules == FightRulesEnum.MentalFight)
            {
                return new Bot(chosenJob.JobLevel);
            }

            return new Jedi(chosenJob.JobLevel);
        }        

        private void RewardNinja(Ninja ninja, Job chosenJob)
        {
            int ninjaCashReward = chosenJob.Wage;
            ninja.GetCash(ninjaCashReward);
        }
    }
}
