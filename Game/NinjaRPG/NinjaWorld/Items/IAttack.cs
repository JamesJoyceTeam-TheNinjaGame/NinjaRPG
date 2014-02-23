namespace NinjaWorld.Items
{
    public interface IAttack : IItem
    {
        int AttackPower { get; set; }

        int SuccessRate { get; set; }

        AttackTypeEnum AttackType { get; set; }
    }
}
