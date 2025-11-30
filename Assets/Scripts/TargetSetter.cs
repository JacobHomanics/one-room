using JacobHomanics.Essentials.RPGController;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TargetSetter : MonoBehaviour
{
    public void Set(Transform target)
    {
        Debug.Log("Step1");
        FindAnyObjectByType<PlayerMotor>().transform.root.GetComponentInChildren<TargetManager>().SetTarget(target);
        Debug.Log("Step 800");

    }
}
