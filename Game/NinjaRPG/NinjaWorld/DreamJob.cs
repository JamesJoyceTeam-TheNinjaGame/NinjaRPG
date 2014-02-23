namespace NinjaWorld
{
    public class DreamJob : Building
    {
        private const string BuildingName = "Dream Job";
        private static bool isBossDefeated = false;

        public DreamJob()
            : base(BuildingName)
        {
        }

        public void Apply(Ninja ninja)
        {
            if (!isBossDefeated)
            {
                Evil enemy = new Boss();

                Arena fight = new Arena(string.Format("Going for the {0}", BuildingName), FightRulesEnum.BalancedFight, ninja, enemy);

                fight.Fight();

                if (fight.IsNinjaWiner)
                {
                    isBossDefeated = true;
                    this.Congratulations();
                }
                else
                {
                    // ToDo: for Andrei: ??any string message for the looser
                }
            }
            else
            {
                this.Congratulations();
            }
        }

        private void Congratulations()
        {
            // ToDo: Andrey. Say:"Congratulation you complete the game"
        }
    }
}