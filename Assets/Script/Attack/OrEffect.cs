using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class OrEffect : AttackEffect
{
    [SerializeReference] public List<AttackEffect> effects = new();

    public override void Apply(IAttacker sender, IDamageable target)
    {
        effects[UnityEngine.Random.Range(0, effects.Count)].Apply(sender, target);
    }
}
