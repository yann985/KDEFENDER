using System;

public interface IDamageable : IHealthOwner
{
    void ApplyHealthDiff(float value);

    event Action OnDeath;
}
