namespace WorldOfNinja.Buildings
{
    using System.Collections.Generic;
    using Interfaces;

    public abstract class CommercialBuilding : WorldObject, IGameObject
    {
        private IList<ICommercialItem> goods;

        public CommercialBuilding(string name, IList<ICommercialItem> allGoods)
            : base(name)
        {
            this.goods = allGoods;
            TurnOver = 0;
        }

        public static int TurnOver { get; private set; }

        public IList<ICommercialItem> Goods
        {
            get
            {
                return new List<ICommercialItem>(this.goods);
            }
        }

        public void Sell(ICommercialItem commercialItem, IHero hero)
        {
            // If ninja have enough money to pay, he pays
            if (hero.PayCash(commercialItem.Price))
            {
                // If ninja accepts the item he takes it
                if (hero.GetItem(commercialItem))
                {
                    int index = this.goods.IndexOf(commercialItem);
                    this.goods.RemoveAt(index);

                    var itemRecharge = commercialItem.Clone();
                    this.goods.Insert(index, itemRecharge as ICommercialItem);
                    TurnOver += commercialItem.Price;
                }
                else
                {
                    // Return money
                    hero.GetCash(commercialItem.Price);
                }
            }
        }
    }
}