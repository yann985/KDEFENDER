using System;

public static class AttackEffectEventBus
{
    public static event Action<AttackContext> OnDamageEvent;
    public static event Action<AttackContext> OnHealEvent;

    public static void RaiseDamage(AttackContext context) => OnDamageEvent?.Invoke(context);

    public static void RaiseHeal(AttackContext context) => OnHealEvent?.Invoke(context);
}
