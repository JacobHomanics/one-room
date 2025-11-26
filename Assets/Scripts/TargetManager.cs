using UnityEngine;
using UnityEngine.Events;
using JacobHomanics.Timer;
using TMPro;
using JacobHomanics.Core.OverlapShape;
using JacobHomanics.HealthSystem;
using JacobHomanics.HealthSystem.UI;
using JacobHomanics.TrickedOutUI;

public class TargetManager : MonoBehaviour
{
    public Transform target;
    public bool isHostile;
    public Timer timer;

    public Action action;

    public OverlapShape overlapShape;

    public GameObject targetUI;
    public HealthAdapter enemyHealthAdapter;

    public EntityNameDisplayer characterNameDisplayer;

    public BaseAnimatedFill baf;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            target = null;
            isHostile = false;
        }

        if (target)
            enemyHealthAdapter.health = target.GetComponentInChildren<Health>();

        if (target)
            characterNameDisplayer.entity = target.GetComponentInChildren<Entity>();

        targetUI.SetActive(target);



        if (isHostile && timer.IsDurationReached())
        {
            var cols = overlapShape.Cast();

            foreach (var col in cols)
            {
                if (col.transform.root.name == target.name)
                {
                    action.Initiate();
                }
            }
        }
    }
}
