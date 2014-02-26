namespace WorldOfNinja
{
    using System;

    public struct FightRules
    {
        private double forceAttackCoefficient;
        private double mindAttackCoefficient;

        public FightRules(double mindAttackCoefficient, double forceAttackCoefficient)
            : this()
        {
            this.ForceAttackCoefficient = forceAttackCoefficient;
            this.MindAttackCoefficient = mindAttackCoefficient;
        }

        public double MindAttackCoefficient
        {
            get
            {
                return this.mindAttackCoefficient;
            }

            private set
            {
                if (value < 0 || value > 1)
                {
                    throw new ArgumentOutOfRangeException("MindAttack coeficient must be between 0 and 1");
                }

                this.mindAttackCoefficient = value;
            }
        }

        public double ForceAttackCoefficient
        {
            get
            {
                return this.forceAttackCoefficient;
            }

            private set
            {
                if (value < 0 || value > 1)
                {
                    throw new ArgumentOutOfRangeException("ForceAttack coeficient must be between 0 and 1");
                }

                this.forceAttackCoefficient = value;
            }
        }

        public static bool operator ==(FightRules one, FightRules two)
        {
            return one.ForceAttackCoefficient == two.ForceAttackCoefficient &&
                one.MindAttackCoefficient == two.MindAttackCoefficient;
        }

        public static bool operator !=(FightRules one, FightRules two)
        {
            return one.ForceAttackCoefficient != two.ForceAttackCoefficient ||
                one.MindAttackCoefficient != two.MindAttackCoefficient;
        }

        public override bool Equals(object obj)
        {
            FightRules rule = (FightRules)obj;
            return this.ForceAttackCoefficient == rule.ForceAttackCoefficient &&
                    this.MindAttackCoefficient == rule.MindAttackCoefficient;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
