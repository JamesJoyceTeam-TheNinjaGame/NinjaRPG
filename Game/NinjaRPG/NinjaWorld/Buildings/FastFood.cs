namespace NinjaWorld.Buildings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NinjaWorld.Items;

    /// <summary>
    /// implementin singleton design pattern instance of FastFood class
    /// </summary>
    public sealed class FastFood : CommercialBuilding
    {
        private static readonly Lazy<FastFood> Lazy = new Lazy<FastFood>(() => new FastFood());

        private static List<ICommercial> allGoods = new List<ICommercial>()
        {
            new Energizer(EnergizerEnum.Bgurger, "Big Max"),
            new Energizer(EnergizerEnum.Coffee, "LaVisio"),
            new Energizer(EnergizerEnum.Cola, "dr.Peter"),
            new Energizer(EnergizerEnum.EnergyDrink, "Doberman"),
            new Energizer(EnergizerEnum.IceCream, "Icegida"),
            new Energizer(EnergizerEnum.Pizza, "A la Programa")
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
