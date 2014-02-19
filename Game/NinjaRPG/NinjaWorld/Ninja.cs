namespace NinjaWorld
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
            : base(name)
        {
            this.TotalEnergy = StartEnergy;
            this.ForceLevel = InitialLevel;
            this.MentalLevel = InitialLevel;
            this.CurrentStepForceLevel = InitialStep;
            this.CurrentStepMentalLevel = InitialStep;
            this.TotalStepsToNextForceLevel = InitialTotalSteps;
            this.TotalStepsToNextMentalLevel = InitialTotalSteps;
            this.Cash = 50;
            this.ForcePowers = new List<Powers>();
            this.MentalPowers = new List<Powers>();
            this.BagOfItems = new List<ICommercial>();
            this.GetItem(Academy.ListOfPowers[0]);
        }

        public List<Powers> ForcePowers { get; private set; }

        public List<Powers> MentalPowers { get; private set; }

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

        public bool UpMentalLevel()
        {
            if (this.MentalLevel < MaxMentalLevel &&
               this.CurrentStepMentalLevel == this.TotalStepsToNextMentalLevel)
            {
                this.MentalLevel++;
                this.TotalStepsToNextMentalLevel++;
                this.CurrentStepMentalLevel = InitialStep;
                return true;

                // TODO: Event? Accept next mental Item
            }
            else if (this.CurrentStepMentalLevel < this.TotalStepsToNextMentalLevel)
            {
                this.CurrentStepMentalLevel++;
            }
            return false;
        }

        public void GetCash(int cash)
        {
            this.Cash += cash;
        }

        public bool PayForItem(ICommercial commercialItem)
        {
            if (this.Cash >= commercialItem.Price)
            {
                this.Cash -= commercialItem.Price;
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
                    this.ForcePowers.Add(item as Powers);
                    return true;
                }
                else if ((item as Powers).AttackType == AttackTypeEnum.MindAttack)
                {
                    this.MentalPowers.Add(item as Powers);
                    return true;
                }
            }
            else if (item is Recreations)
            {
                this.TotalEnergy += (item as Recreations).EnergyUpgrade;
                return true;
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
        public Items UseItem(Items item)
        {
            if (item is ICommercial)
            {
                if (item is EnergizingItems)
                {
                    this.CurrentEnergy += (item as EnergizingItems).HealingPoints;
                }
                this.BagOfItems.Remove(item as ICommercial);            
            }
            return item;
        }
    }
}