using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AndEffect : AttackEffect
{
    [SerializeReference] public List<AttackEffect> effects = new();

    public override void Apply(IAttacker sender, IDamageable target)
    {
        foreach (var effect in effects)
            effect.Apply(sender, target);
    }
}
