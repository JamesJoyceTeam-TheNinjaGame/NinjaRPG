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

            // Singleton test 
            // Creating the only one instance of Dreamjob Building
            DreamJob onlyOneInstance = DreamJob.getInstance("Testt");
            //Getting the hashcode to ensure it is unique
            Console.WriteLine(onlyOneInstance.GetHashCode());
            //Printing name ...
            Console.WriteLine(onlyOneInstance.Name);
           // Trying to instantiate new DreamJob Building
            DreamJob secondInstance = DreamJob.getInstance("Testt");
            // Trying to print its name ... fault is the old name of the 1st instance :)
            Console.WriteLine(onlyOneInstance.Name);
            // OMG the HashCode is like that on the first instance ... I think we have Singleton for that buildng ! 
            Console.WriteLine(secondInstance.GetHashCode());

        }
    }
}