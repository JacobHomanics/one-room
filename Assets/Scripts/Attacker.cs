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

            anim.Play("Aavegotchi_MeleeAttack_Right");
            timer.Restart();
        }
    }
}
