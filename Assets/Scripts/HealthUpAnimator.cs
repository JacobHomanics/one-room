using JacobHomanics.HealthSystem;
using UnityEngine;
using UnityEngine.Events;

public class HealthUpAnimator : MonoBehaviour
{
    public Health health;
    // public Animator anim;
    // public string animName;

    // public AudioSource audioSource;

    public UnityEvent<float> OnHealthUp;

    void OnEnable()
    {
        health.OnHealthUp.AddListener(HandleHealthDown);
        health.OnShieldUp.AddListener(HandleShieldUp);
    }

    void OnDisable()
    {
        health.OnHealthUp.RemoveListener(HandleHealthDown);
        health.OnShieldUp.RemoveListener(HandleShieldUp);
    }

    public UnityEvent<float> OnShieldUp;

    void HandleShieldUp(float value)
    {
        OnShieldUp?.Invoke(value);
    }

    public void HandleHealthDown(float value)
    {
        // anim.SetTrigger(animName);
        OnHealthUp?.Invoke(value);
        // audioSource.Play();
    }
}
