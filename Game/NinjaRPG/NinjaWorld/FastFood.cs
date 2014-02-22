namespace NinjaWorld
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// implementin singleton design pattern instance of FastFood class
    /// </summary>
    public sealed class FastFood : CommercialBuilding
    {
        private static List<ICommercial> AllGoods = new List<ICommercial>()
        {
            new EnergizingItems(EnergizerEnum.Bgurger, "Big Max"),
            new EnergizingItems(EnergizerEnum.Coffee, "LaVisio"),
            new EnergizingItems(EnergizerEnum.Cola, "dr.Peter"),
            new EnergizingItems(EnergizerEnum.EnergyDrink, "Doberman"),
            new EnergizingItems(EnergizerEnum.IceCream, "Icegida"),
            new EnergizingItems(EnergizerEnum.Pizza, "A la Programa")
        }.OrderBy(en => en.Price).ToList();

        private static readonly Lazy<FastFood> Lazy = new Lazy<FastFood>(() => new FastFood());

        private FastFood()
            : base("Fast Food", AllGoods)
        {
        }

        public static FastFood Instance 
        { 
            get { return Lazy.Value; } 
        }
    }
}
