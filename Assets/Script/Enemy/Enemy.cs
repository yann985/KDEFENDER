using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable, IAttacker, IPathFollower
{
    [SerializeField] float maxHealth = 100f;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] int value = 10;
    [SerializeReference] AttackEffect effect = new DamageEffect();

    Level level;
    int waypointIndex;

    public float MaxHealth => maxHealth;
    public float CurrentHealth { get; private set; }
    public float MoveSpeed => moveSpeed;
    public int Value => value;
    public AttackEffect Effect => effect;

    public event Action OnDeath;

    void Awake()
    {
        CurrentHealth = maxHealth;
    }

    public void SetLevel(Level newLevel)
    {
        level = newLevel;
        waypointIndex = 0;
        transform.position = level.waypoints[0].position;
    }

    void Update()
    {
        if (level == null) return;

        if (waypointIndex >= level.waypoints.Length)
        {
            // Destroy(gameObject);
            // return;
            waypointIndex = 0;
        }

        Vector3 target = level.waypoints[waypointIndex].position;
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);

        if (transform.position == target)
            waypointIndex++;
    }

    public void ApplyHealthDiff(float value)
    {
        if (CurrentHealth <= 0f) return;

        CurrentHealth = Mathf.Clamp(CurrentHealth + value, 0f, maxHealth);
        Debug.Log($"[Enemy] {name} : {CurrentHealth}/{maxHealth} PV ({value:+0;-0})");
        if (CurrentHealth <= 0f)
        {
            OnDeath?.Invoke();
            Destroy(gameObject);
        }
    }

    public void Attack(IDamageable target)
    {
        effect.Apply(this, target);
    }
}
