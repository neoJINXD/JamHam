using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    [SerializeField] Transform target;
    private NavMeshAgent agent;
    private Animator anim;

    private int movingHash;

    private bool ded = false;

    void Awake() 
    {
        // target = GameManager.instance.coil.transform;
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        movingHash = Animator.StringToHash("Moving");
        anim.SetBool(movingHash, true);
    }

    void Update() 
    {   
        if (!ded)
        {
            agent.SetDestination(target.position);
        }
        // TODO make sure to attack if close to coil
    }

    public void Die()
    {
        // agent.SetDestination(transform.position);
        ded = true;
        Destroy(agent);
    }

}
