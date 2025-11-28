using System.Collections.Generic;
using JacobHomanics.Timer;
using JacobHomanics.Core.OverlapShape;
using JacobHomanics.HealthSystem;
using UnityEngine;
using UnityEngine.Events;

public class TargetManagerSpin : MonoBehaviour
{
    public TargetManager targetManager;
    public float variancePercentage;

    public float damage;

    public OverlapShape shape;

    public Timer timer;

    //Event for timer not reached
    // Reset timer on use
    //Event for Attack
    //Change to try attack

    public UnityEvent OnCooldown;

    public UnityEvent OnSuccess;

    public void TryAttack()
    {

        if (!timer.IsDurationReached())
        {
            Debug.Log("Cooldown invoked");
            OnCooldown?.Invoke();
            return;
        }


        List<Transform> hitRoots = new List<Transform>();

        var cols = shape.Cast();

        foreach (var col in cols)
        {
            bool isPresent = false;

            foreach (var root in hitRoots)
            {
                if (root == col.transform.root)
                {
                    isPresent = true;
                    break;
                }
            }

            if (!isPresent)
            {
                var diff = damage * (variancePercentage / 100f);
                var rn = Random.Range(damage - diff, damage + diff);
                col.transform.root.GetComponentInChildren<Health>().Damage(rn);
                hitRoots.Add(col.transform.root);
            }
        }

        OnSuccess?.Invoke();

    }
}
