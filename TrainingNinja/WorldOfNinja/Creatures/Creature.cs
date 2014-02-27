namespace WorldOfNinja.Creatures
{
    using System.Text.RegularExpressions;
    using Interfaces;

    public abstract class Creature : WorldObject, ICreature
    {
        private int currentEnergy;

        public Creature(string name, int totalEnergy, int forceLevel, int mentalLevel)
            : base(name)
        {
            this.TotalEnergy = totalEnergy;
            this.CurrentEnergy = this.TotalEnergy;
            this.MentalLevel = mentalLevel;
            this.ForceLevel = forceLevel;
        }

        public int CurrentEnergy
        {
            get
            {
                return this.currentEnergy;
            }

            private set
            {
                if (value < 0)
                {
                    value = 0;
                }

                if (value > this.TotalEnergy)
                {
                    value = this.TotalEnergy;
                }

                this.currentEnergy = value;
            }
        }

        public int TotalEnergy { get; protected set; }        

        public int MentalLevel { get; protected set; }

        public int ForceLevel { get; protected set; }

        public virtual void DecreaseCurrentEnergy(int damage)
        {
            this.currentEnergy -= damage;
        }

        public void ResetCurrentEnergy()
        {
            this.currentEnergy = this.TotalEnergy;
        }

        public bool IsAlive()
        {
            if (this.currentEnergy > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public abstract Hit Attack();       
    }
}
