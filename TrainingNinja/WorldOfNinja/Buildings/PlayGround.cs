namespace WorldOfNinja.Buildings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Item;

    public sealed class Playground : CommercialBuilding
    {
        private static readonly Lazy<Playground> Lazy = new Lazy<Playground>(() => new Playground());

        private static List<ICommercialItem> recreationGoods = new List<ICommercialItem>() 
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
            get { return Lazy.Value; }
        }
    }
}
