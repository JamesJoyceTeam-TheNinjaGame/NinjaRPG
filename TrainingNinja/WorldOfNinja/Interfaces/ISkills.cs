namespace WorldOfNinja.Interfaces
{
    public interface ISkill : IUsable
    {
        int AttackPower { get; }

        int SuccessRate { get; }

        PowerEnum AttackType { get; }
    }
}