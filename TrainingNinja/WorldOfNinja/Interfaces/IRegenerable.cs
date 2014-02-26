namespace WorldOfNinja.Interfaces
{
    public interface IRegenerable : ICreature
    {
        void IncreaseCurrentEnergy(int energy);
    }
}
