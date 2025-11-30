using JacobHomanics.Essentials.RPGController;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class HostileSetter : MonoBehaviour
{
    public void Set(bool value)
    {
        FindAnyObjectByType<PlayerMotor>().transform.root.GetComponentInChildren<TargetManager>().isHostile = true;
    }
}
