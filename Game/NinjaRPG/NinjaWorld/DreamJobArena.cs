namespace NinjaWorld
{
    public class DreamJobArena : Arena
    {
        public DreamJobArena(string name, FightRulesEnum fightRules)
            : base(name, fightRules)
        {
        }

        public override void OfferReward()
        {
            // TODO: Offer GAMEOVER + WIN!!!
            base.OfferReward(); 
        }
    }
}
