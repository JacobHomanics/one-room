using JacobHomanics.Core.OverlapShape;
using JacobHomanics.HealthSystem;
using UnityEngine;
using UnityEngine.Events;

public class TargetManagerAttacker : MonoBehaviour
{
    public TargetManager targetManager;
    public float variancePercentage;

    public float damage;

    public UnityEvent OnAttackSuccess;

    public OverlapShape shape;

    public void Attack()
    {
        var cols = shape.Cast();

        bool isPresent = false;

        foreach (var col in cols)
        {
            if (col.transform.root == targetManager.target)
            {
                isPresent = true;
                break;
            }
        }



        if (targetManager.target && isPresent)
        {
            var diff = damage * (variancePercentage / 100f);

            var rn = Random.Range(damage - diff, damage + diff);
            targetManager.target.GetComponentInChildren<Health>().Damage(rn);

            OnAttackSuccess?.Invoke();
        }

    }
}
