namespace ConsoleInstantationTester
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NinjaWorld;
    using NinjaWorld.Buildings;
    using NinjaWorld.Creatures;
    using NinjaWorld.Items;
    using NinjaWorld.Jobs;

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

            Bag<IItem> check = new Bag<IItem>() { 
            
                new SpecialPower(AttackTypeEnum.ForceAttack, "Name", 12, 12, 12),
                new Recreation("recreation"),
                new Energizer(EnergizerEnum.Bgurger, "energy")
            };

            check.Insert(0, new Recreation("ssss"));
            

            foreach (IItem item in check)
            {
                Console.WriteLine(item);
            }
        }
    }
}