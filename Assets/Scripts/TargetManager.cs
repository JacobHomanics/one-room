using UnityEngine;
using UnityEngine.Events;
using JacobHomanics.Timer;
using TMPro;
using JacobHomanics.Core.OverlapShape;

public class TargetManager : MonoBehaviour
{
    public Transform target;
    public bool isHostile;
    public Timer timer;

    public Action action;

    public TMP_Text text;

    public OverlapShape overlapShape;


    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            target = null;
            isHostile = false;
        }

        if (target)
            text.text = target.name;
        else
            text.text = "";


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
