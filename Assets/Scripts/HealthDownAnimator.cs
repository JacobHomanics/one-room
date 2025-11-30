using JacobHomanics.HealthSystem;
using UnityEngine;
using UnityEngine.Events;

public class HealthDownAnimator : MonoBehaviour
{
    public Health health;
    // public Animator anim;
    // public string animName;

    // public AudioSource audioSource;

    public UnityEvent<float> OnHealthDown;

    void OnEnable()
    {
        health.OnHealthDown.AddListener(HandleHealthDown);
    }

    void OnDisable()
    {
        health.OnHealthDown.RemoveListener(HandleHealthDown);

    }

    public void HandleHealthDown(float value)
    {
        // anim.SetTrigger(animName);
        OnHealthDown?.Invoke(value);
        // audioSource.Play();
    }
}
