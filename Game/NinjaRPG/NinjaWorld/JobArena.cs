namespace NinjaWorld
{
    public class JobArena : Arena
    {
        public JobArena(string name, FightRulesEnum fightRules)
            : base(name, fightRules)
        {
        }

        public override void OfferReward()
        {
            // TODO: Offer MONEY
            base.OfferReward(); 
        }
    }
}
