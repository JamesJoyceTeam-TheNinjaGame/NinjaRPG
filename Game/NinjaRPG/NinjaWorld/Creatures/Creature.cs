namespace NinjaWorld.Creatures
{
    using System;
    using System.Text.RegularExpressions;

    [Serializable]
    public abstract class Creature
    {     
        private string name;
        private int currentEnergy;

        public Creature(string name, int startEnergy)
        {
            this.Name = name;
            this.CreatureType = this.GetType().Name;
            this.TotalEnergy = startEnergy;
            this.CurrentEnergy = this.TotalEnergy;
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

                if (value > this.TotalEnergy)
                {
                    value = this.TotalEnergy;
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

            protected set
            {
                if (!Regex.IsMatch(value, @"\b[A-Za-z][A-Za-z][A-Za-z]+\b"))
                {
                    throw new ImproperlyDefinedCreatureException(string.Format("{0} name must be at least 3 symbols and could contain only latin letters", this.CreatureType));
                }

                this.name = value;
            }
        }

        public string CreatureType { get; private set; }               

        public int TotalEnergy { get; protected set; }
  
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

        public void ReceiveDamage(int damage)
        {
            this.currentEnergy -= damage;
        }
    }
}