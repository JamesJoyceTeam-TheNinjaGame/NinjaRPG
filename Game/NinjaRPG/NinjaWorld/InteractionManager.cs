using NinjaWorld.Buildings;
using NinjaWorld.Creatures;
using NinjaWorld.Items;
using NinjaWorld.Jobs;

namespace NinjaWorld
{
    public class InteractionManager
    {

        public virtual void Attack (IItem item, Creature attackedCreature)
        {
            var power = this.UseItem(item) as IAttack;
            
            if (power == null)
            {
                return 0;
            }
            else
            {
                return HitCalculator.DynamicDamageCalculator(power);
            }
        }
    }
}
