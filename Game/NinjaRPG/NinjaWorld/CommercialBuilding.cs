namespace NinjaWorld
{
    public class CommercialBuilding : Building
    {
        private ICommercial[] goods;

        public CommercialBuilding(string name, params ICommercial[] allGoods)
            : base(name)
        {
            this.goods = allGoods;
        }

        public ICommercial[] Goods
        {
            get
            {
                return (ICommercial[])this.goods.Clone();
            }
        }

        // TODO: Sell() ??
    }
}
