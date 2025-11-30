using JacobHomanics.HealthSystem;
using UnityEngine;

public class HealthDownAnimator : MonoBehaviour
{
    public Health health;
    public Animator anim;
    public string animName;

    public AudioSource audioSource;

    void OnEnable()
    {
        health.OnHealthDown.AddListener(OnHealthDown);
    }

    void OnDisable()
    {
        health.OnHealthDown.RemoveListener(OnHealthDown);

    }

    public void OnHealthDown(float value)
    {
        anim.SetTrigger(animName);
        // audioSource.Play();
    }
}
