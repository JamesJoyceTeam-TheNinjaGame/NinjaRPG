namespace NinjaWorld
{
    using System;

    public interface ICommercial : ICloneable
    {
        int Price { get; set; }

        string Name { get; }
    }
}
