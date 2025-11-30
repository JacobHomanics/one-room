using JacobHomanics.Essentials.RPGController;
using UnityEngine;
using UnityEngine.AI;

public class AITarget : MonoBehaviour
{
    public Transform target;
    public float attackDistance;
    public NavMeshAgent agent;
    public Animator anim;

    private float distance;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = FindAnyObjectByType<PlayerMotor>().transform;

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(agent.transform.position, target.position);
        if (distance < attackDistance)
        {
            agent.isStopped = true;
        }

        anim.SetBool("IsMoving", distance < attackDistance);
    }
}
