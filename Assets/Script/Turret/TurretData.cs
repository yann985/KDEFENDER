using UnityEngine;

[CreateAssetMenu(fileName = "TurretData", menuName = "KDefender/Turret Data")]
public class TurretData : ScriptableObject
{
    public float attackRange;
    [SerializeReference] public AttackEffect attackEffect = new DamageEffect();
    [SerializeReference] public ShapeSearcher shapeSearcher = new CircleSearch();
    public Sprite turretSprite;
}
