using System.Collections.Generic;
using JacobHomanics.Core.OverlapShape;
using JacobHomanics.HealthSystem;
using UnityEngine;

public class TargetManagerSpin : MonoBehaviour
{
    public TargetManager targetManager;
    public float variancePercentage;

    public float damage;

    public OverlapShape shape;


    public void Attack()
    {

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
    }
}
