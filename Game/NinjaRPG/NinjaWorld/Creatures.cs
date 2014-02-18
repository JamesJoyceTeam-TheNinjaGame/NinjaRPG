namespace NinjaWorld
{
    using System.Text.RegularExpressions;

    public abstract class Creatures
    {
        protected const int MaximalTotalEnergy = 5000;
        private const int MinimalTotalEnergy = 50;
     
        private string name;
        private int totalEnergy;
        private int currentEnergy;

        public Creatures(string name, int totalEnergy)
        {
            this.Name = name;
            this.CreatureType = this.GetType().Name;
            this.TotalEnergy = totalEnergy;
            this.CurrentEnergy = this.totalEnergy;
        }

        public int CurrentEnergy
        {
            get 
            { 
                return this.currentEnergy; 
            }

            set 
            {
                if (value < 0)
                {
                    value = 0;
                }

                if (value > this.totalEnergy)
                {
                    value = this.totalEnergy;
                }

                this.currentEnergy = value;
            }
        }        

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (!Regex.IsMatch(value, @"\b[A-Za-z][A-Za-z][A-Za-z]+\b"))
                {
                    throw new ImproperlyDefinedCreatureException(string.Format("{0} name must be at least 3 symbols and could contain only latin letters", this.CreatureType));
                }

                this.name = value;
            }
        }

        public string CreatureType { get; private set; }               

        public int TotalEnergy
        {
            get 
            { 
                return this.totalEnergy; 
            }

            set 
            {
                if (value < MinimalTotalEnergy || value > MaximalTotalEnergy)
                {
                    throw new ImproperlyDefinedCreatureException(string.Format("Total energy could not be less than {0} or more than {1}", MaximalTotalEnergy, MaximalTotalEnergy));
                }

                this.totalEnergy = value; 
            }
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
    }
}
