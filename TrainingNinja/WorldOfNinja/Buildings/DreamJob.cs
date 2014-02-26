namespace WorldOfNinja.Buildings
{
    using Creatures;
    using Interfaces;

    public static class DreamJob 
    {
        public const string BuildingName = "Dream Job";
        private static bool isBossDefeated = false;
        private static string status = "Improve yourself and apply for the dream job!";

        public static string Status
        {   
            get 
            {
                return status;
            } 
        }

        public static void Apply(IHero hero)
        {
            if (!isBossDefeated)
            {
                Boss enemy = new Boss();

                Arena fight = new Arena(string.Format("Going for the {0}", BuildingName), new FightRules(1, 1), hero, enemy);

                // event?
                IUsable item = hero.ListOfFightingSkills[0];
                do
                {
                    // IUsable item = selected Item!
                    item = hero.ListOfFightingSkills[0];
                }
                while (fight.Fight(item));
                //// event end

                if (fight.IsHeroWinner)
                {
                    isBossDefeated = true;
                    status = "Congratulation you've got it!";
                }
            }
        }
    }
}