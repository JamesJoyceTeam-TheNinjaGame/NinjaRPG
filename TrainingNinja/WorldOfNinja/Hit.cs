namespace WorldOfNinja
{
    public struct Hit
    {
        public Hit(int hitPower)
            : this()
        {
            this.Power = hitPower;
        }

        public Hit(int hitPower, PowerEnum hitType)
            : this(hitPower)
        {
            this.Type = hitType;
        }

        public int Power { get; private set; }

        public PowerEnum Type { get; private set; }
    }   
}