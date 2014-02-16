namespace ConsoleInstantationTester
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NinjaWorld;

    public class Instatest
    {
        public static void Main()
        {
            Ninja ninja = new Ninja("Gogo");

            string name = RandomeEvilName.RandomName(RandomeEvilName.JediNames);
            string second = RandomeEvilName.RandomName(RandomeEvilName.RobotNames);
            string trd = RandomeEvilName.RandomName(RandomeEvilName.AssasinNames);
            Console.WriteLine(name);
            Console.WriteLine(second);
            Console.WriteLine(trd);

            Console.WriteLine(ninja.Cash);
        }
    }
}