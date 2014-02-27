namespace WorldOfNinja.Item
{
    using Interfaces;
    using System;

    [Serializable]

    public abstract class UsableItem : WorldObject, IUsable
    {
        public UsableItem(string name)
            : base(name)
        { 
        }
    }
}
