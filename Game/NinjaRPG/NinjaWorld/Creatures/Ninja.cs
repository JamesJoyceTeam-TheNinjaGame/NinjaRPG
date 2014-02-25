namespace NinjaWorld.Creatures
{
    using System;    
    using System.Collections.Generic;
    using System.Linq;
    using NinjaWorld.Items;

    [Serializable]
    public class Ninja : Creature
    {
        private const int MaxForceLevel = 10;
        private const int MaxMentalLevel = 10;
        private const int StartEnergy = 100;
        private const int InitialLevel = 1;
        private const int InitialStep = 1;
        private const int InitialTotalSteps = 5;
        private const int InitialCash = 50;
        private const int MaxItems = 30;
        private const int MaxItemsPerCategory = 10;
        private int forceItems;
        private int mentalItems;
        private int energyItems;

        public Ninja(string name)
            : base(name, StartEnergy)
        {
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
            this.GetItem(new Power(AttackTypeEnum.ForceAttack, "Fist Fight", 10, 60));
            this.GetItem(new Power(AttackTypeEnum.MindAttack, "Diversion", 10, 80));
            forceItems = 0;
            mentalItems = 0;
            energyItems = 0;
        }

        public IList<IAttack> ForcePowers { get; private set; }

        public IList<IAttack> MentalPowers { get; private set; }

        public IList<ICommercial> BagOfItems { get; private set; }

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

        public void SetNinjaName(string name)
        {
            this.Name = name;
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
                throw new ArgumentException("You don't have enough money to by it.");
            }
        }

        public bool GetItem(IItem item)
        {
            if (item is Recreation)
            {
                this.TotalEnergy += (item as Recreation).UpgradeTotalEnergy;
                this.CurrentEnergy += (item as Recreation).UpgradeTotalEnergy;
                
                return true;
            }
            else if (item is ICommercial)
            {
                 //TODO: NEED TO CHECK IF THERE IS A PLACE IN THE BAG here.

                if ((item is Energizer))  //If these checks are missing the program blows in Home and Fight panels
                {
                    if (energyItems >= MaxItemsPerCategory)
                    {
                        return false;
                    }
                    else
                    {
                        energyItems++;
                    }
                }
                else if ((item as IAttack).AttackType == AttackTypeEnum.ForceAttack)
                {
                    if (forceItems >= MaxItemsPerCategory)
                    {
                        return false;
                    }
                    else
                    {
                        forceItems++;
                    }
                }
                else if ((item as IAttack).AttackType == AttackTypeEnum.MindAttack)
                {
                    if (mentalItems >= MaxItemsPerCategory)
                    {
                        return false;
                    }
                    else
                    {
                        mentalItems++;
                    }
                }

                //HAPPY ???

                this.BagOfItems.Add(item as ICommercial);
                
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

        public int Attack(IItem item)
        {
            var power = this.UseItem(item) as IAttack;
            
            if (power == null)
            {
                return 0;
            }
            else
            {
                return HitCalculator.DynamicDamageCalculator(power);
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