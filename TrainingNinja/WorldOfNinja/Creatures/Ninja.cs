namespace WorldOfNinja.Creatures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;

    [Serializable]
    public class Ninja : Creature, IHero
    {
        private const int BagOfItemCapacity = 30;
        private const int InitialStepToLevel = 1;
        private int cash;
        private int maxForceLevel;
        private int maxMentalLevel;
        private IUsable engagedItem;

        public Ninja(string name)
            : base(name, InitialNinjaSettings.NinjaTotalEnergy, InitialNinjaSettings.NinjaInitialForceLevel, InitialNinjaSettings.NinjaInitialMentalLevel)
        {
            this.cash = InitialNinjaSettings.NinjaCash;
            this.ListOfFightingSkills = InitialNinjaSettings.NinjaListOfFightingSkills;
            this.ListOfMentalSkills = InitialNinjaSettings.NinjaListOfMentalSkills;
            this.BagOfItems = InitialNinjaSettings.NinjaBagOfItems;
            this.maxForceLevel = InitialNinjaSettings.NinjaMaxForceLevel;
            this.maxMentalLevel = InitialNinjaSettings.NinjaMaxMentalLevel;
            this.TotalStepsToNextForceLevel = InitialNinjaSettings.NinjaInitialStepsToNextLevel;
            this.TotalStepsToNextMentalLevel = InitialNinjaSettings.NinjaInitialStepsToNextLevel;
            this.CurrentStepForceLevel = InitialStepToLevel;
            this.CurrentStepMentalLevel = InitialStepToLevel;
        }

        public int CurrentStepForceLevel { get; private set; }

        public int CurrentStepMentalLevel { get; private set; }

        public int TotalStepsToNextForceLevel { get; private set; }

        public int TotalStepsToNextMentalLevel { get; private set; }

        public int Cash
        {
            get { return this.cash; }
        }

        public IList<ISkill> ListOfMentalSkills { get; private set; }

        public IList<ISkill> ListOfFightingSkills { get; private set; }

        public IList<ICommercialItem> BagOfItems { get; private set; }

        public void GetCash(int cash)
        {
            if (cash >= 0)
            {
                this.cash += cash;
            }
            else
            {
                throw new ArgumentException("Cash must not be negative");
            }
        }

        public bool PayCash(int payCash)
        {
            if (this.cash >= payCash)
            {
                this.cash -= payCash;
                return true;
            }

            return false;
        }

        public virtual bool GetItem(IUsable item)
        {
            if (item is IEnergyExpandable)
            {
                this.TotalEnergy += (item as IEnergyExpandable).UpgradeTotalEnergy;
                this.ResetCurrentEnergy();

                return true;
            }
            else if (item is ICommercialItem && this.BagOfItems.Count < BagOfItemCapacity)
            {
                this.BagOfItems.Add(item as ICommercialItem);
                this.BagOfItems = this.BagOfItems
                    .OrderBy(it => it.GetType().Name)
                    .ThenBy(it => it.Price)
                    .ToList();

                return true;
            }
            else if (item is ISkill)
            {
                var newAttack = item as ISkill;

                if (newAttack.AttackType == PowerEnum.ForcePower)
                {
                    this.ListOfFightingSkills.Add(newAttack);

                    return true;
                }
                else if (newAttack.AttackType == PowerEnum.MentalPower)
                {
                    this.ListOfMentalSkills.Add(newAttack);

                    return true;
                }
            }

            return false;
        }

        public virtual void UseItem(IUsable item)
        {
            if (item is ICommercialItem)
            {
                if (item is IEnergizer)
                {
                    this.IncreaseCurrentEnergy((item as IEnergizer).HealingPoints);
                }

                this.BagOfItems.Remove(item as ICommercialItem);
            }
                              
            this.engagedItem = item;
        }

        public bool UpForceLevel()
        {
            if (this.ForceLevel < this.maxForceLevel &&
                this.CurrentStepForceLevel == this.TotalStepsToNextForceLevel)
            {
                this.ForceLevel++;
                this.TotalStepsToNextForceLevel++;
                this.CurrentStepForceLevel = InitialStepToLevel;
                return true;
            }
            else if (this.CurrentStepForceLevel < this.TotalStepsToNextForceLevel)
            {
                this.CurrentStepForceLevel++;
            }

            return false;
        }

        public bool UpMentalLevel()
        {
            if (this.MentalLevel < this.maxMentalLevel &&
               this.CurrentStepMentalLevel == this.TotalStepsToNextMentalLevel)
            {
                this.MentalLevel++;
                this.TotalStepsToNextMentalLevel++;
                this.CurrentStepMentalLevel = InitialStepToLevel;
                return true;
            }
            else if (this.CurrentStepMentalLevel < this.TotalStepsToNextMentalLevel)
            {
                this.CurrentStepMentalLevel++;
            }

            return false;
        }

        public void IncreaseCurrentEnergy(int energy)
        {
            this.CurrentEnergy += energy;
        }

        public override Hit Attack()
        {
            var skill = this.engagedItem as ISkill;
            int power = HitCalculator.DynamicDamageCalculator(skill);
            return new Hit(power, skill.AttackType);
        }
    }
}
