namespace NinjaWorld
{
    using System;

    public class HitCalculator
    {
        protected int DynamicPowerHit(int maxPower, int averageSuccess)
        {
            Random rand = new Random();
            int result = new int();
            for (int i = 0; i < 10; i++)
            {
                if (rand.Next(0, averageSuccess + 1) <= averageSuccess)
                {
                    result += maxPower;
                }
            }

            return result / 10;
        }
    }
}
