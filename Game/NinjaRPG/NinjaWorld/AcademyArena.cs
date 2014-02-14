namespace NinjaWorld
{
    public class AcademyArena : Arena
    {
        public AcademyArena(string name, FightRulesEnum fightRules)
            : base(name, fightRules)
        {
        }

        public override void OfferReward()
        {
            // TODO: Offer KNOWLEDGE + SKILLS
            base.OfferReward(); 
        }
    }
}
