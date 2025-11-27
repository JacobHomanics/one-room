using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TargetSetter : MonoBehaviour
{
    public void Set(Transform target)
    {
        Debug.Log("Step1");
        FindAnyObjectByType<TargetManager>().SetTarget(target);
        Debug.Log("Step 800");

    }
}
