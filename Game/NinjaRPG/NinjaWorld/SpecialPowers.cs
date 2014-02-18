namespace NinjaWorld
{
    using System;

    public class SpecialPowers : Powers, ICommercial
    {
        private int price;

        public SpecialPowers(AttackTypeEnum attackType, string name, int price, int attackPower, int successRate)
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
            return new SpecialPowers(this.AttackType, (string)this.Name.Clone(), this.Price, this.AttackPower, this.SuccessRate);
        }
    }
}
