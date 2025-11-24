using JacobHomanics.Timer;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    public Timer timer;
    public Animator anim;

    void Update()
    {
        if (timer.IsDurationReached())
        {

            anim.SetTrigger("Attack");
            timer.Restart();
        }
    }
}
