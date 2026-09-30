using UnityEngine;

public class Turret : MonoBehaviour, IAutoAttacker, ITargetSearcher
{
    [SerializeField] TurretData data;
    [SerializeField] float attackSpeed = 1f;

    float cooldown;

    public AttackEffect Effect => data.attackEffect;
    public float AttackSpeed => attackSpeed;
    public float Range => data.attackRange;
    public ShapeSearcher ShapeSearcher => data.shapeSearcher;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = data.turretSprite;
    }

    void Update()
    {
        cooldown -= Time.deltaTime;
        if (cooldown > 0f) return;

        if (ShapeSearcher.TryGetAllOfTypesInShape(transform.position, Range, out IDamageable[] targets))
        {
            Attack(targets[0]);
            cooldown = 1f / attackSpeed;
        }
    }

    public void Attack(IDamageable target)
    {
        var targetComponent = (Component)target;
        Debug.Log($"[Turret] {name} tire sur {targetComponent.name}");
        Debug.DrawLine(transform.position, targetComponent.transform.position, Color.red, 0.1f);

        Effect.Apply(this, target);
    }
}
