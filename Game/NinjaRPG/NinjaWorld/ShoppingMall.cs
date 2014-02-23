namespace NinjaWorld
{
    using System;
    using System.Collections.Generic;
   
    public sealed class ShoppingMall : CommercialBuilding
    {
        private static readonly Lazy<ShoppingMall> SM = new Lazy<ShoppingMall>(() => new ShoppingMall());

        private static List<ICommercial> specialGoods = new List<ICommercial>()
        {
            new SpecialPower(AttackTypeEnum.ForceAttack, "Hammer", 25, 25, 65),
            new SpecialPower(AttackTypeEnum.ForceAttack, "Baseball Bat", 100, 50, 70),
            new SpecialPower(AttackTypeEnum.ForceAttack, "Shuriken", 300, 100, 75), 
            new SpecialPower(AttackTypeEnum.ForceAttack, "Tomahawk", 1000, 250, 80), 
            new SpecialPower(AttackTypeEnum.ForceAttack, "Poison Dart", 2500, 500, 90), 
            new SpecialPower(AttackTypeEnum.MindAttack, "Forum Flag", 25, 25, 65),
            new SpecialPower(AttackTypeEnum.MindAttack, "Virus", 100, 50, 70),
            new SpecialPower(AttackTypeEnum.MindAttack, "Csharp Book", 450, 150, 75),
            new SpecialPower(AttackTypeEnum.MindAttack, "Help from Teammate", 1000, 250, 85),
            new SpecialPower(AttackTypeEnum.MindAttack, "Help from Trainer", 2500, 500, 95)
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
