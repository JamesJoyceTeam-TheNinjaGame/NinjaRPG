namespace NinjaWorld
{
    public class Arena : Building
    {        
        public Arena(string name, FightRulesEnum fightRules, Evil creature)
            : base(name) 
        {
            this.FightRules = fightRules;
        }

        public FightRulesEnum FightRules { get; set; }

        public bool IsNinjaWiner { get; private set; }

        public void Fight()
        {
            // ToDO: Implement Fight
            this.IsNinjaWiner = true; //// this must be conditional
        }        
    }
}
