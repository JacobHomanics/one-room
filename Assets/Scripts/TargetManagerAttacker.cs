using JacobHomanics.Core.OverlapShape;
using JacobHomanics.HealthSystem;
using JacobHomanics.Timer;

using UnityEngine;
using UnityEngine.Events;

public class TargetManagerAttacker : MonoBehaviour
{
    public TargetManager targetManager;
    public float variancePercentage;

    public float damage;

    public UnityEvent OnAttackSuccess;

    public OverlapShape shape;

    public Timer timer;

    //That ability is not ready yet
    //My target is too far away
    //I have no target

    public UnityEvent OnCooldown;
    public UnityEvent OnSuccess;

    public void TryAttack()
    {
        if (!timer.IsDurationReached())
        {
            Debug.Log("on Coold");
            OnCooldown?.Invoke();
            return;
        }

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
