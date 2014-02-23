namespace ConsoleInstantationTester
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NinjaWorld;
    using NinjaWorld.Creatures;
    using NinjaWorld.Items;
    using NinjaWorld.Buildings;

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

            Power one = new Power(AttackTypeEnum.ForceAttack, "SssS", 3, 3);
            Power two = new Power(AttackTypeEnum.ForceAttack, "SaaaS", 3, 3);

            List<Power> sheld = new List<Power>()
            {
                one,
                two
            };

            foreach (var item in sheld)
            {
                Console.WriteLine(item.AttackType);
            }
        }
    }
}