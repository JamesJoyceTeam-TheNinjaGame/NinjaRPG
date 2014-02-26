namespace WorldOfNinja.Interfaces
{
    public interface IJob : IGameObject
    {
        FightRules JobFightRules { get; }

        int Wage { get; }
        
        string Possition { get; }
        
        int JobLevel { get; }
    }
}
