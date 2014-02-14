namespace NinjaWorld
{
    using System;

    public abstract class Evil : Creatures
    {
        public Evil(string name, int totalEnergy)
            : base(name, totalEnergy)
        {
        }        
    }
}