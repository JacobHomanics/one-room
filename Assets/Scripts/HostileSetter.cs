using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class HostileSetter : MonoBehaviour
{
    public void Set(bool value)
    {
        FindAnyObjectByType<TargetManager>().isHostile = true;
    }
}
