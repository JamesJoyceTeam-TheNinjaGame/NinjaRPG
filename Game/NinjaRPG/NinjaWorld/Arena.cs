namespace NinjaWorld
{
    public class Arena : Building
    {
        public Evil Creature { get; private set; }

        public Arena(string name, FightRulesEnum fightRules, Evil creature)
            : base(name) 
        {
            this.FightRules = fightRules;
            this.Creature = creature;
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
