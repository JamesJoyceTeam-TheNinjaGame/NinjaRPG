namespace WorldOfNinja.Item
{
    using Interfaces;

    public class SpecialPower : Skill, ISkill, ICommercialItem
    {
        private int price;

        public SpecialPower(PowerEnum attackType, string name, int price, int attackPower, int successRate)
            : base(attackType, name, attackPower, successRate)
        {
            this.Price = price;
        }

        public int Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value < 0)
                {
                    throw new ImproperlyDefinedItemException("Price could be only positive integer");
                }

                this.price = value;
            }
        }

        public object Clone()
        {
            return new SpecialPower(this.AttackType, this.Name, this.Price, this.AttackPower, this.SuccessRate);
        }
    }
}
