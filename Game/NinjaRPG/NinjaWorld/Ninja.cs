﻿namespace NinjaWorld
{
    using System.Collections.Generic;
    using System.Linq;

    public class Ninja : Creatures
    {
        private const int MaxForceLevel = 10;
        private const int MaxMentalLevel = 10;
        private const int StartEnergy = 100;
        private const int InitialLevel = 1;
        private const int InitialStep = 1;
        private const int InitialTotalSteps = 5;
        private const int InitialCash = 50;
        private const int MaxItems = 20;

        public Ninja(string name)
            : base(name, StartEnergy)
        {
            this.ForceLevel = InitialLevel;
            this.MentalLevel = InitialLevel;
            this.CurrentStepForceLevel = InitialStep;
            this.CurrentStepMentalLevel = InitialStep;
            this.TotalStepsToNextForceLevel = InitialTotalSteps;
            this.TotalStepsToNextMentalLevel = InitialTotalSteps;
            this.Cash = 50;
            this.ForcePowers = new Powers[MaxForceLevel];
            this.MentalPowers = new Powers[MaxMentalLevel];
            this.BagOfItems = new List<ICommercial>();
        }

        public Powers[] ForcePowers { get; private set; }

        public Powers[] MentalPowers { get; private set; }

        public List<ICommercial> BagOfItems { get; private set; }

        public int Cash { get; private set; }

        public int ForceLevel { get; private set; }

        public int TotalStepsToNextForceLevel { get; private set; }

        public int CurrentStepForceLevel { get; private set; }

        public int MentalLevel { get; private set; }

        public int TotalStepsToNextMentalLevel { get; private set; }

        public int CurrentStepMentalLevel { get; private set; }

        public void UpForce()
        {
            if (this.ForceLevel < MaxForceLevel &&
                this.CurrentStepForceLevel == this.TotalStepsToNextForceLevel)
            {
                this.ForceLevel++;
                this.TotalStepsToNextForceLevel++;
                this.CurrentStepForceLevel = InitialStep;

                // TODO: Event? Accept next power Item
            }
            else if (this.CurrentStepForceLevel < this.TotalStepsToNextForceLevel)
            {
                this.CurrentStepForceLevel++;
            }
        }

        public void UpMental()
        {
            if (this.MentalLevel < MaxMentalLevel &&
               this.CurrentStepMentalLevel == this.TotalStepsToNextMentalLevel)
            {
                this.MentalLevel++;
                this.TotalStepsToNextMentalLevel++;
                this.CurrentStepMentalLevel = InitialStep;

                // TODO: Event? Accept next mental Item
            }
            else if (this.CurrentStepMentalLevel < this.TotalStepsToNextMentalLevel)
            {
                this.CurrentStepMentalLevel++;
            }
        }

        public void GetCash(int cash)
        {
            this.Cash += cash;
        }

        public bool PayCash(int cash)
        {
            if (this.Cash >= cash)
            {
                this.Cash -= cash;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GetItem(Items item)
        {
            // TODO: Be very careful to not overlap powers here!
            if (item is Powers && !(item is SpecialPowers))
            {
                if ((item as Powers).AttackType == AttackTypeEnum.ForceAttack)
                {
                    this.ForcePowers[this.ForceLevel - InitialLevel] = item as Powers;
                    return true;
                }
                else if ((item as Powers).AttackType == AttackTypeEnum.MindAttack)
                {
                    this.MentalPowers[this.MentalLevel - InitialLevel] = item as Powers;
                    return true;
                }
            }
            else if (item is Recreations)
            {
                this.TotalEnergy += (item as Recreations).EnergyUpgrade;
            }
            else if (item is ICommercial && this.BagOfItems.Count < MaxItems)
            {
                this.BagOfItems.Add(item as ICommercial);
                this.BagOfItems = this.BagOfItems
                    .OrderBy(it => it.GetType().Name)
                    .ThenBy(it => it.Price)
                    .ToList();
                return true;
            }
            
            return false;
        }

        // TODO: DONE ! Energizer Used // Recreation USED
        public ICommercial UseItem(ICommercial item)
        {
            if (item is Energizers)
            {
                this.CurrentEnergy += (item as Energizers).HealingPoints;
            }

            this.BagOfItems.Remove(item);
            return item;            
        }
    }
}
