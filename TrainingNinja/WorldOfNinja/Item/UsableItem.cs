namespace WorldOfNinja.Item
{
    using Interfaces;

    public abstract class UsableItem : WorldObject, IUsable
    {
        public UsableItem(string name)
            : base(name)
        { 
        }
    }
}
