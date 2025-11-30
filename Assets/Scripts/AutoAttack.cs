using UnityEngine;
using UnityEngine.Events;
using JacobHomanics.Timer;
using TMPro;
using JacobHomanics.Core.OverlapShape;
using JacobHomanics.HealthSystem;
using JacobHomanics.HealthSystem.UI;
using JacobHomanics.TrickedOutUI;
using JacobHomanics.Utilities;

public class AutoAttack : MonoBehaviour
{
    public TargetManager targetManager;

    public Timer timer;

    public Action action;

    public OverlapShape overlapShape;


    void Update()
    {
        if (targetManager.isHostile && timer.IsDurationReached())
        {
            var cols = overlapShape.Cast();

            foreach (var col in cols)
            {
                Debug.Log(col.transform.root);
                if (col.transform.root == targetManager.target)
                {
                    action.Initiate();
                    break;
                }
            }
        }
    }
}
