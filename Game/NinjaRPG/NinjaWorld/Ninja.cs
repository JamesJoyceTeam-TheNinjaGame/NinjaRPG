﻿namespace NinjaWorld
{
    using System.Collections.Generic;
    using System.Linq;

    public class Ninja : Creature
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
            this.Cash = InitialCash;
            this.ForcePowers = new List<IAttack>();
            this.MentalPowers = new List<IAttack>();
            this.BagOfItems = new List<ICommercial>();
            this.GetItem(Academy.ListOfPowers[0]);
            this.GetItem(Gym.ListOfPowers[0]);
        }

        public List<IAttack> ForcePowers { get; private set; }

        public List<IAttack> MentalPowers { get; private set; }

        public List<ICommercial> BagOfItems { get; private set; }

        public int Cash { get; private set; }

        public int ForceLevel { get; private set; }

        public int TotalStepsToNextForceLevel { get; private set; }

        public int CurrentStepForceLevel { get; private set; }

        public int MentalLevel { get; private set; }

        public int TotalStepsToNextMentalLevel { get; private set; }

        public int CurrentStepMentalLevel { get; private set; }

        public bool UpForceLevel()
        {
            if (this.ForceLevel < MaxForceLevel &&
                this.CurrentStepForceLevel == this.TotalStepsToNextForceLevel)
            {
                this.ForceLevel++;
                this.TotalStepsToNextForceLevel++;
                this.CurrentStepForceLevel = InitialStep;
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
            if (this.MentalLevel < MaxMentalLevel &&
               this.CurrentStepMentalLevel == this.TotalStepsToNextMentalLevel)
            {
                this.MentalLevel++;
                this.TotalStepsToNextMentalLevel++;
                this.CurrentStepMentalLevel = InitialStep;
                return true;
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

        public bool GetItem(IItem item)
        {
            if (item is Recreation)
            {
                this.TotalEnergy += (item as Recreation).UpgradeTotalEnergy;
                
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
            else if (item is IAttack)
            {
                var newAttack = item as IAttack;
             
                if (newAttack.AttackType == AttackTypeEnum.ForceAttack)
                {
                    this.ForcePowers.Add(newAttack);
                
                    return true;
                }
                else if (newAttack.AttackType == AttackTypeEnum.MindAttack)
                {
                    this.MentalPowers.Add(newAttack);
                    
                    return true;
                }
            }

            return false;
        }

        public int Attack(IItem item, FightRulesEnum rules)
        {
            var power = this.UseItem(item) as IAttack;
            
            if (power == null)
            {
                return 0;
            }
            else
            {
                return HitCalculator.DynamicDamageCalculator(power, rules);
            }
        }
        
        private IItem UseItem(IItem item)
        {
            if (item is ICommercial)
            {
                if (item is Energizer)
                {
                    this.CurrentEnergy += (item as Energizer).HealingPoints;
                }

                this.BagOfItems.Remove(item as ICommercial);
            }

            return item;
        }
    }
}