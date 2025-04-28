using UnityEngine;
using UnityEngine.AI;

public class AIEnemyController : MonoBehaviour
{
    public Transform player;
    public float chaseRange = 10f;
    public float attackRange = 2f;
    public float attackDamage = 10f;
    public float attackCooldown = 1.5f;

    private NavMeshAgent agent;
    private float lastAttackTime;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance < chaseRange)
        {
            agent.SetDestination(player.position);

            if (distance < attackRange &amp;&amp; Time.time > lastAttackTime + attackCooldown)
            {
                Attack();
                lastAttackTime = Time.time;
            }
        }
        else
        {
            agent.ResetPath();
        }
    }

    void Attack()
    {
        // Implement damage to player here
        Debug.Log("Enemy attacks player for " + attackDamage + " damage.");
    }
}
