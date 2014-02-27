namespace WorldOfNinja.Buildings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Item;

    /// <summary>
    /// implementin singleton design pattern instance of FastFood class
    /// </summary>
    public sealed class FastFood : CommercialBuilding
    {
        private static readonly Lazy<FastFood> Lazy = new Lazy<FastFood>(() => new FastFood());

        private static List<ICommercialItem> allGoods = new List<ICommercialItem>()
        {
            new Energizer(100, "Dr.Peter's Cola"),
            new Energizer(50, "Coffee LaVasio"),
            new Energizer(20, "Big Max Burger"),
            new Energizer(300, "Ice Cream Icegida"),
            new Energizer(500, "Pizza A La Programa"),
            new Energizer(200, "Doberman Energy Drink"),
        }.OrderBy(en => en.Price).ToList();
        
        private FastFood()
            : base("Fast Food", allGoods)
        {
        }

        public static FastFood Instance
        {
            get { return Lazy.Value; }
        }
    }
}
