using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    [SerializeField] Transform target;
    private NavMeshAgent agent;
    private Animator anim;

    private int movingHash;
    private int runHash;
    private int attackHash;

    private bool ded = false;
    [SerializeField]private bool isAttackingPlayer;

    void Awake() 
    {
        // target = GameManager.instance.coil.transform;
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        movingHash = Animator.StringToHash("Moving");
        runHash = Animator.StringToHash("Running");
        attackHash = Animator.StringToHash("Attack");

        isAttackingPlayer = Random.Range(0f,1f) <= 0.5 ? true : false;
        if (isAttackingPlayer)
        {
            agent.speed = 3f;
            anim.SetBool(runHash, true);
        }
        else
        {
            agent.speed = 0.5f;
            anim.SetBool(movingHash, true);
        }
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
