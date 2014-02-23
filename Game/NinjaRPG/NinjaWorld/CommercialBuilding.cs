namespace NinjaWorld
{
    using System;
    using System.Collections.Generic;

    public class CommercialBuilding : Building
    {
        private List<ICommercial> goods;

        public CommercialBuilding(string name, List<ICommercial> allGoods)
            : base(name)
        {
            this.goods = allGoods;
        }

        public List<ICommercial> Goods
        {
            get
            {
                return new List<ICommercial>(this.goods);
            }
        }
        
        // TODO: Remove or Implement Turnover.
        public int Turnover { get; private set; }

        public void Sell(ICommercial commercialItem, Ninja ninja)
        {
            // If ninja have enough money to pay, he pays
            if (ninja.PayForItem(commercialItem))
            {
                // If ninja accepts the item he takes it
                if (ninja.GetItem(commercialItem as Item))
                {
                    int index = this.goods.IndexOf(commercialItem);
                    this.goods.RemoveAt(index);

                    var itemRecharge = commercialItem.Clone();
                    this.goods.Insert(index, itemRecharge as ICommercial);
                }
                else
                {
                    // Return money
                    ninja.GetCash(commercialItem.Price);
                }
            }
        }        
    }
}
