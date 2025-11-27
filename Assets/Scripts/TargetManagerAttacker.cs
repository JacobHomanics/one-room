using JacobHomanics.HealthSystem;
using UnityEngine;

public class TargetManagerAttacker : MonoBehaviour
{
    public TargetManager targetManager;
    public float variancePercentage;

    public float damage;

    public void Attack()
    {
        var diff = damage * (variancePercentage / 100f);

        var rn = Random.Range(damage - diff, damage + diff);
        targetManager.target.GetComponentInChildren<Health>().Damage(rn);
    }
}
