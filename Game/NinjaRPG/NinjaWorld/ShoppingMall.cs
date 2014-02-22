namespace NinjaWorld
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
   
    public sealed class ShoppingMall : CommercialBuilding
    {
        private static List<ICommercial> specialGoods = new List<ICommercial>()
        {
            new SpecialPowers(AttackTypeEnum.ForceAttack, "Hammer" , 25, 25, 65 ),
            new SpecialPowers(AttackTypeEnum.ForceAttack, "BaseballBat", 100, 50, 70),
            new SpecialPowers(AttackTypeEnum.ForceAttack, "Shuriken", 300, 100, 75), 
            new SpecialPowers(AttackTypeEnum.ForceAttack, "Tomahawk", 1000, 250, 80), 
            new SpecialPowers(AttackTypeEnum.ForceAttack, "PoisonDart", 2500, 500, 90), 
            new SpecialPowers(AttackTypeEnum.MindAttack, "ForumFlag", 25, 25, 65),
            new SpecialPowers(AttackTypeEnum.MindAttack, "HelpFromTeamMate", 100, 50, 70),
            new SpecialPowers(AttackTypeEnum.MindAttack, "CsharpBook", 450, 150, 75),
            new SpecialPowers(AttackTypeEnum.MindAttack, "HelpFromTrainer", 1000, 250, 85),
            new SpecialPowers(AttackTypeEnum.MindAttack, "Virus", 2500, 500, 95)
            
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
