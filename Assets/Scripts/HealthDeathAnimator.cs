using JacobHomanics.HealthSystem;
using UnityEngine;
using UnityEngine.Events;

public class HealthDeathAnimator : MonoBehaviour
{
    public Health health;

    // public Animator anim;
    // public string thing;

    public UnityEvent Died;

    void OnEnable()
    {
        health.OnHealthZero.AddListener(OnDeath);
    }

    void OnDisable()
    {
        health.OnHealthZero.RemoveListener(OnDeath);
    }

    void OnDeath()
    {
        Died?.Invoke();
    }
}
