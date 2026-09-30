using System;

[Serializable]
public class HealEffect : AttackEffect
{
    public float heal = 10f;

    public override void Apply(IAttacker sender, IDamageable target)
    {
        target.ApplyHealthDiff(heal);
        AttackEffectEventBus.RaiseHeal(new AttackContext { sender = sender, target = target, value = heal });
    }
}
