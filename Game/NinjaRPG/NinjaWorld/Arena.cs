using System.Threading;
namespace NinjaWorld
{
    public class Arena : Building
    {
        public Evil Creature { get; private set; }
        public Ninja ninja { get; private set; }
        private int NinjaLife { get; set; }
        private int EvilLife { get; set; }
        public Arena(string name, FightRulesEnum fightRules, Ninja ninja, Evil creature)
            : base(name) 
        {
            this.FightRules = fightRules;
            this.ninja = ninja;
            this.Creature = creature;
            NinjaLife = ninja.CurrentEnergy;
            EvilLife = creature.CurrentEnergy;
        }

        public FightRulesEnum FightRules { get; set; }

        public bool IsNinjaWiner { get; private set; }

        //public bool IsNinjaTurn { get; set; }

        public bool Fight(FightRulesEnum fightRules, Evil evil, bool isNinjaTurn, int power, int energizer = 0)  //to add success
        {
            if(isNinjaTurn)
            {
                this.EvilLife -= power;
            }
            else
            {
                this.NinjaLife += energizer - (int)fightRules;
            }
              
            if (this.NinjaLife < 1 || this.EvilLife < 1)
            {
              return true;
            }
      
            return false;
        }        
    }
}
