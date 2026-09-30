using System;

[Serializable]
public class DamageEffect : AttackEffect
{
    public float damage = 10f;

    public override void Apply(IAttacker sender, IDamageable target)
    {
        target.ApplyHealthDiff(-damage);
        AttackEffectEventBus.RaiseDamage(new AttackContext { sender = sender, target = target, value = damage });
    }
}
