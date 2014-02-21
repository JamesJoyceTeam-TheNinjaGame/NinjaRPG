namespace NinjaWorld
{
    using System;
    
    public static class Randomizer
    {
        private static Random rand = new Random();

        public static Random Rand 
        {
            get { return rand; } 
        }
    }
}
