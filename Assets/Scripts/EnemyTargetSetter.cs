using JacobHomanics.HealthSystem;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class EnemyTargetSetter : MonoBehaviour
{
    public Health health;

    public void Set()
    {
        // FindAnyObjectByType<TargetManager>().baf.SetFillImmediate(health.Current, health.Max);
    }
}
