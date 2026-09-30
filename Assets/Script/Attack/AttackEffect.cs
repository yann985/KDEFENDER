using System;

[Serializable]
public abstract class AttackEffect
{
    public abstract void Apply(IAttacker sender, IDamageable target);
}
