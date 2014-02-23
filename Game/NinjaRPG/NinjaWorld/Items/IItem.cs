namespace NinjaWorld.Items
{
    public interface IItem
    {
        string ItemType { get; }

        string Name { get; set; }
    }
}
