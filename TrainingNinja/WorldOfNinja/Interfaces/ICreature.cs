namespace WorldOfNinja.Interfaces
{
    public interface ICreature : IGameObject
    {
        int CurrentEnergy { get; }

        int TotalEnergy { get; }

        int MentalLevel { get; }

        int ForceLevel { get; }

        void DecreaseCurrentEnergy(int damage);

        void ResetCurrentEnergy();

        bool IsAlive();

        Hit Attack();
    }
}