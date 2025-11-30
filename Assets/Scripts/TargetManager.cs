using UnityEngine;
using UnityEngine.Events;
using JacobHomanics.Timer;
using TMPro;
using JacobHomanics.Core.OverlapShape;
using JacobHomanics.HealthSystem;
using JacobHomanics.HealthSystem.UI;
using JacobHomanics.TrickedOutUI;
using JacobHomanics.Utilities;
using JacobHomanics.Essentials.RPGController;

public class TargetManager : MonoBehaviour
{
    public Transform target;
    public bool isHostile;
    // public Timer timer;

    // public Action action;

    // public OverlapShape overlapShape;

    public GameObject targetUI;
    public HealthAdapter enemyHealthAdapter;

    public EntityNameDisplayer characterNameDisplayer;

    // public AnimatedImageFill baf;

    public void SetIsHostile(bool value)
    {
        isHostile = value;
    }

    public void SetTarget(Transform target)
    {
        Debug.Log("Step2");

        this.target = target;
        Debug.Log("Step3");

        // baf.image.fillAmount = baf.SetFillImmediate(target.GetComponentInChildren<Health>().Current, target.GetComponentInChildren<Health>().Max);
    }

    public bool isPlayer;

    void Awake()
    {
        if (!isPlayer)
            target = FindAnyObjectByType<PlayerMotor>().transform.root;
    }

    void Update()
    {
        if (isPlayer)
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
        }

        // if (isHostile && timer.IsDurationReached())
        // {
        //     var cols = overlapShape.Cast();

        //     foreach (var col in cols)
        //     {
        //         Debug.Log(col.transform.root);
        //         if (col.transform.root == target)
        //         {
        //             action.Initiate();
        //             break;
        //         }
        //     }
        // }
    }
}
