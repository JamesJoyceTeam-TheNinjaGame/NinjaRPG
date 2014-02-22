namespace NinjaWorld
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public sealed class Playground : CommercialBuilding
    {
        private static List<ICommercial> recreationGoods = new List<ICommercial>() 
        {
            new Recreations("PlayingPoker"),
            new Recreations("VideoGames"),
            new Recreations("Bowling"),
            new Recreations("Billiards"),
            new Recreations("Dance")
        }.OrderBy(rec => rec.Price).ToList();

        private static readonly Lazy<Playground> PG = new Lazy<Playground>(() => new Playground());

         private Playground()
            : base("Playground", recreationGoods)
        {
        }

         public static Playground Instance
         {
             get { return PG.Value; }
         }
    }
}
