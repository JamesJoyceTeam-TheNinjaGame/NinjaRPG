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

            Console.WriteLine(ninja.Cash);
        }
    }
}