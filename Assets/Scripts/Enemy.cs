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

    [SerializeField]private float distance;

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
            target = GameObject.FindWithTag("Player").transform;
        else
            target = GameObject.FindWithTag("Target").transform;
        StartChasing();
    }

    void Update() 
    {   
        distance = Vector3.Distance(transform.position, target.position);
        if (!ded)
        {

            if (distance <= 1.7f)
            {
                // TODO make sure to attack if close to coil
                agent.speed = 0f;
                agent.isStopped = true;
                anim.SetBool(movingHash, false);
                anim.SetBool(runHash, false);
                anim.SetBool(attackHash, true);
            }
            else
            {
                agent.SetDestination(target.position);
                // StartChasing();
            }
        }
    }

    public void Die()
    {
        // agent.SetDestination(transform.position);
        ded = true;
        Destroy(agent);
    }

    private void StartChasing()
    {
        agent.isStopped = false;
        if (isAttackingPlayer)
        {
            agent.speed = 3f;
            anim.SetBool(runHash, true);
            // target = GameManager.instance.player.transform;
        }
        else
        {
            agent.speed = 0.5f;
            anim.SetBool(movingHash, true);
            // target = GameManager.instance.coil.transform;
        }
        anim.SetBool(attackHash, false);
    }

    public void AttackEnd()
    {
        distance = Vector3.Distance(transform.position, target.position);
        if (!(distance <= 1.7f))
        {
            StartChasing();
        }
    }

}
