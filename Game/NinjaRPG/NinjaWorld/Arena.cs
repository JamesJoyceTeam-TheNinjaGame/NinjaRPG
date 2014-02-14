namespace NinjaWorld
{
    public abstract class Arena : Building
    {        
        public Arena(string name, FightRulesEnum fightRules)
            : base(name) 
        {
            this.FightRules = fightRules;
        }

        public FightRulesEnum FightRules { get; set; }
   
        public void Fight()
        {
            // ToDO: Implement
        }
        
        public virtual void OfferReward()
        {
            // ToDo Implement
        }
    }
}
