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
    }

    void OnDisable()
    {
        health.OnHealthUp.RemoveListener(HandleHealthDown);

    }

    public void HandleHealthDown(float value)
    {
        // anim.SetTrigger(animName);
        OnHealthUp?.Invoke(value);
        // audioSource.Play();
    }
}
