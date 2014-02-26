namespace NinjaWorld.Buildings
{
    using NinjaWorld.Creatures;
    using NinjaWorld.Items;

    /// <summary>
    /// The fight happens here
    /// </summary>
    public class Arena : Building
    {
        private Evil creature;
        private Ninja ninja;
        private FightRulesEnum fightRules;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Arena"/> class.
        /// </summary>
        /// <param name="name">The battle name</param>
        /// <param name="fightRules">Fighting rules for damage calculator</param>
        /// <param name="ninja">Our ninja</param>
        /// <param name="creature">Enemy to fight with the ninja</param>
        public Arena(string name, FightRulesEnum fightRules, Ninja ninja, Evil creature)
            : base(name) 
        {
            this.fightRules = fightRules;
            this.creature = creature;
            this.ninja = ninja;
            HitCalculator.SetFightRusles(fightRules);
        }

        /// <summary>
        /// returns true if ninja won the battle
        /// </summary>
        public bool IsNinjaWiner { get; private set; }

        // Todo: Andrey = Pick ITEM ?? // for now leaving this hack
        public IItem NinjaPickItem()
        {
            return this.ninja.ForcePowers[0];
        }

        /// <summary>
        /// The battle turnst here
        /// </summary>
        /// <returns>return true if still fighting</returns>        
        public bool Fight()
        {
            if (this.ninja.IsAlive())
            {
                int damage = this.ninja.Attack(this.NinjaPickItem());
                this.creature.ReceiveDamage(damage);
            }
            else
            {
                this.IsNinjaWiner = false;
                return false;
            }

            if (this.creature.IsAlive())
            {
                int damage = this.creature.Attack();
                this.ninja.ReceiveDamage(damage);
            }
            else
            {
                this.IsNinjaWiner = true;
                return false;
            }
            
            return true;
        }        
    }
}
