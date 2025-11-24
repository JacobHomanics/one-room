using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LookAtController : MonoBehaviour
{
    public Transform targetLookingAt;
    public Transform targetToLookAt;

    public bool reverseY;
    public bool reverseX;

    public bool followOnX;
    public bool followOnY;
    public bool followOnZ;
    public bool reverse;

    public UnityEvent LookedAt;
    public bool lookAtPlayer;

    private void Start()
    {
        if (lookAtPlayer)
        {
            targetToLookAt = Camera.main.transform;
        }
    }
    private void Update()
    {
        LookAt();
    }
    public void LookAt()
    {
        if (targetToLookAt == null)
            return;

        if (!reverse)
            targetLookingAt.LookAt(targetToLookAt.position);
        else
            targetLookingAt.LookAt(2 * targetLookingAt.position - targetToLookAt.position);

        var targetEulers = Vector3.zero;

        if (followOnX)
        {
            if (!reverseX)
                targetEulers.x = targetLookingAt.eulerAngles.x;
            else
                targetEulers.x = -targetLookingAt.eulerAngles.x;

        }

        if (followOnY)
        {
            if (!reverseY)
                targetEulers.y = targetLookingAt.eulerAngles.y;
            else
                targetEulers.y = -targetLookingAt.eulerAngles.y;

        }

        if (followOnZ)
            targetEulers.z = targetLookingAt.eulerAngles.z;

        targetLookingAt.eulerAngles = targetEulers;


        Debug.DrawLine(targetLookingAt.position, targetToLookAt.position, Color.green);
        LookedAt?.Invoke();
    }
}