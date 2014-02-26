namespace WorldOfNinja.Buildings
{
    using System;
    using Interfaces;
    using Item;

    public class Arena : WorldObject, IGameObject
    {
        public const string Loser = "Hero is looser!";        
        private ICreature creature;
        private IHero hero;
        private FightRules fightRules;

        public Arena(string name, FightRules fightRules, IHero hero, ICreature creature)
            : base(name)
        {
            this.fightRules = fightRules;
            this.creature = creature;
            this.hero = hero;
        }

        public ICreature Creature 
        { 
            get { return this.creature; } 
        }

        public bool IsHeroWinner { get; private set; }

        public bool Fight(IUsable pickedItem)
        {
            if ((pickedItem is ICommercialItem &&
                this.hero.BagOfItems.Contains(pickedItem as ICommercialItem)) ||
                (pickedItem is Skill &&
                (this.hero.ListOfFightingSkills.Contains(pickedItem as ISkill) ||
                this.hero.ListOfMentalSkills.Contains(pickedItem as ISkill))))
            {
                if (this.hero.IsAlive())
                {
                    this.hero.UseItem(pickedItem);
                    int damage = this.AttackPowerModifier(this.hero);
                    this.creature.DecreaseCurrentEnergy(damage);
                }
                else
                {
                    this.IsHeroWinner = false;
                    this.hero.ResetCurrentEnergy();
                    return false;
                }

                if (this.creature.IsAlive())
                {
                    int damage = this.AttackPowerModifier(this.creature);
                    this.hero.DecreaseCurrentEnergy(damage);
                }
                else
                {
                    this.IsHeroWinner = true;
                    this.hero.ResetCurrentEnergy();
                    return false;
                }

                return true;
            }
            else
            {
                throw new ApplicationException("Game rule violation! Hero cannot engage items that don't belong to him");
            }
        }

        private int AttackPowerModifier(ICreature attacker)
        {
            Hit hit = attacker.Attack();
            int damage = new int();
            if (hit.Type == PowerEnum.ForcePower)
            {
                damage = (int)(hit.Power * this.fightRules.ForceAttackCoefficient);
            }
            else if (hit.Type == PowerEnum.MentalPower)
            {
                damage = (int)(hit.Power * this.fightRules.MindAttackCoefficient);
            }

            return damage;
        }
    }
}