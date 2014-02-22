namespace NinjaWorld
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
   
    public sealed class ShoppingMall : CommercialBuilding
    {
        private static List<ICommercial> specialGoods = new List<ICommercial>()
        {
            new SpecialPowers(AttackTypeEnum.ForceAttack, "Hammer" , 2, 10, 65 ),
            new SpecialPowers(AttackTypeEnum.ForceAttack, "BaseballBat", 3, 12, 70),
            new SpecialPowers(AttackTypeEnum.ForceAttack, "Shuriken", 6, 15, 75), 
            new SpecialPowers(AttackTypeEnum.ForceAttack, "Tomahawk", 12, 20, 80), 
            new SpecialPowers(AttackTypeEnum.ForceAttack, "PoisonDart", 18, 25, 90), 
            new SpecialPowers(AttackTypeEnum.MindAttack, "ForumFlag", 4, 10, 65),
            new SpecialPowers(AttackTypeEnum.MindAttack, "HelpFromTeamMate", 6, 15, 70),
            new SpecialPowers(AttackTypeEnum.MindAttack, "CsharpBook", 15, 20, 75),
            new SpecialPowers(AttackTypeEnum.MindAttack, "HelpFromTrainer", 20, 25, 85),
            new SpecialPowers(AttackTypeEnum.MindAttack, "Virus", 30, 30, 95)
            
        }.OrderBy(sp => sp.Name).ThenBy(sp => sp.Price).ToList();

        private static readonly Lazy<ShoppingMall> SM = new Lazy<ShoppingMall>(() => new ShoppingMall());

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
