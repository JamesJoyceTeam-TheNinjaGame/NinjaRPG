namespace WorldOfNinja.Buildings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Item;

    public sealed class ShoppingMall : CommercialBuilding
    {
        private static readonly Lazy<ShoppingMall> Lazy = new Lazy<ShoppingMall>(() => new ShoppingMall());

        private static IList<ICommercialItem> specialGoods = new List<ICommercialItem>()
        {
            new SpecialPower(PowerEnum.ForcePower, "Hammer", 25, 25, 65),
            new SpecialPower(PowerEnum.ForcePower, "Baseball Bat", 100, 50, 70),
            new SpecialPower(PowerEnum.ForcePower, "Shuriken", 300, 100, 75), 
            new SpecialPower(PowerEnum.ForcePower, "Tomahawk", 1000, 250, 80), 
            new SpecialPower(PowerEnum.ForcePower, "Poison Dart", 2500, 500, 90), 
            new SpecialPower(PowerEnum.MentalPower, "Forum Flag", 25, 25, 65),
            new SpecialPower(PowerEnum.MentalPower, "Virus", 100, 50, 70),
            new SpecialPower(PowerEnum.MentalPower, "Csharp Book", 450, 150, 75),
            new SpecialPower(PowerEnum.MentalPower, "Help from Teammate", 1000, 250, 85),
            new SpecialPower(PowerEnum.MentalPower, "Help from Trainer", 2500, 500, 95)
            }
                .OrderBy(sp => (sp as ISkill)
                .AttackType)
                .ThenBy(sp => sp.Price)
                .ToList();

        private ShoppingMall()
            : base("ShoppingMall", specialGoods)
        {            
        }

        public static ShoppingMall Instance
        {
            get { return Lazy.Value; }
        }
    }
}