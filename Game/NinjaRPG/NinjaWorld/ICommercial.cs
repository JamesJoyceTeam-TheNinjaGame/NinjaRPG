namespace NinjaWorld
{
    using System;

    public interface ICommercial : ICloneable, IItem
    {
        int Price { get; set; }

        string Name { get; }
    }
}
