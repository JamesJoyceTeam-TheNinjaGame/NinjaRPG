namespace NinjaWorld.Items
{
    using System;

    public interface ICommercial : ICloneable, IItem
    {
        int Price { get; set; }
    }
}
