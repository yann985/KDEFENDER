public interface IAttacker
{
    AttackEffect Effect { get; }

    void Attack(IDamageable target);
}
