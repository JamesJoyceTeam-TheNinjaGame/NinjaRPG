namespace NinjaWorld
{
    using System;
    using System.Collections.Generic;
   
    public sealed class ShoppingMall : CommercialBuilding
    {
        private static readonly Lazy<ShoppingMall> SM = new Lazy<ShoppingMall>(() => new ShoppingMall());

        private static List<ICommercial> specialGoods = new List<ICommercial>()
        {
            new SpecialPowers(AttackTypeEnum.ForceAttack, "Hammer", 25, 25, 65),
            new SpecialPowers(AttackTypeEnum.ForceAttack, "Baseball Bat", 100, 50, 70),
            new SpecialPowers(AttackTypeEnum.ForceAttack, "Shuriken", 300, 100, 75), 
            new SpecialPowers(AttackTypeEnum.ForceAttack, "Tomahawk", 1000, 250, 80), 
            new SpecialPowers(AttackTypeEnum.ForceAttack, "Poison Dart", 2500, 500, 90), 
            new SpecialPowers(AttackTypeEnum.MindAttack, "Forum Flag", 25, 25, 65),
            new SpecialPowers(AttackTypeEnum.MindAttack, "Virus", 100, 50, 70),
            new SpecialPowers(AttackTypeEnum.MindAttack, "Csharp Book", 450, 150, 75),
            new SpecialPowers(AttackTypeEnum.MindAttack, "Help from Teammate", 1000, 250, 85),
            new SpecialPowers(AttackTypeEnum.MindAttack, "Help from Trainer", 2500, 500, 95)
            };

        private ShoppingMall()
            : base("ShoppingMall", specialGoods)
        {
        }

        public static ShoppingMall Instance
        {
            get { return SM.Value; }
        }
    }
}
