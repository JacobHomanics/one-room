using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TargetSetter : MonoBehaviour
{
    public void Set(Transform target)
    {
        FindAnyObjectByType<TargetManager>().target = target;
    }
}
