namespace NinjaWorld
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public sealed class Playground : CommercialBuilding
    {
        private static readonly Lazy<Playground> PG = new Lazy<Playground>(() => new Playground());

        private static List<ICommercial> recreationGoods = new List<ICommercial>() 
        {
            new Recreation("PlayingPoker"),
            new Recreation("VideoGames"),
            new Recreation("Bowling"),
            new Recreation("Billiards"),
            new Recreation("Dance")
        }.OrderBy(rec => rec.Price).ToList();

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
