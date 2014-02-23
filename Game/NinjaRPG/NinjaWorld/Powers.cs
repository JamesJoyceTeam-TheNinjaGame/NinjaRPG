namespace NinjaWorld
{
    public class Powers : Items, IAttack, IItem
    {
        private int attack;
        private int success;

        public Powers(AttackTypeEnum attackType, string name, int attackPower, int successRate)
            : base(name)
        {
            this.SuccessRate = successRate;
            this.AttackPower = attackPower;
            this.AttackType = attackType;
        }

        public AttackTypeEnum AttackType { get; set; }

        public int SuccessRate
        {
            get
            {
                return this.success;
            }

            set
            {
                if (value < 1 || value > 100)
                {
                    throw new ImproperlyDefinedItemException("Succses must be between 1 and 100");
                }

                this.success = value;
            }
        }

        public int AttackPower
        {
            get
            {
                return this.attack;
            }

            set
            {
                if (value < 1)
                {
                    throw new ImproperlyDefinedItemException("Attack Power must be greater than 0");
                }

                this.attack = value;
            }
        }
    }
}