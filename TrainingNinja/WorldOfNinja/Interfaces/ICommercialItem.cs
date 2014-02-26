namespace WorldOfNinja.Interfaces
{
    using System;

    public interface ICommercialItem : IUsable, ICloneable
    {        
        int Price { get; }
    }
}