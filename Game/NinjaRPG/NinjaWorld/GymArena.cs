namespace NinjaWorld
{
    public class GymArena : Arena
    {
        public GymArena(string name, FightRulesEnum fightRules)
            : base(name, fightRules)
        {
        }

        public override void OfferReward()
        {
            // TODO: Offer POWEWR + SKILLS
            base.OfferReward(); 
        }
    }
}
