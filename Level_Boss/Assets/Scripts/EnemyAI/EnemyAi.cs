using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyAi : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public float health;

    // Patroling
    public Transform[] patrolPoints;
    public float timeBetweenPatrols = 2f;
    private int currentPatrolIndex = 0;
    private bool isWaiting = false;
    private bool isPatrolling = false;

    int issCD = 5;

    // Attacking
    public float timeBetweenAttacks;
    private bool alreadyAttacked;

    // States
    public float sightRange, attackRange;
    private bool playerInSightRange, playerInAttackRange;
    bool reayToPlay = true;

    public AudioSource detectplayer;
    public AudioSource startSFX;
    public AudioSource damageSFX;

    public GameManager gameManager;

    public Light pointLight;
    private Color BeforeDiscover = new Color(254f / 255f, 254f / 255f, 43f / 255f);
    private Color AfterDiscover = new Color(142f / 255f, 18f / 255f, 2f / 255f);

    private void Start()
    {
        isPatrolling = true;
        StartCoroutine(Patrol());
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        // Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange && isPatrolling)
        {
            isPatrolling = false;
            StartCoroutine(Patrol());
        }

        if (!playerInSightRange && !playerInAttackRange)
        {
            pointLight.color = BeforeDiscover;
        }

        if (playerInSightRange && !playerInAttackRange)
        {
            isPatrolling = false;
            StopCoroutine(Patrol());
            ChasePlayer();
        }

        if (playerInAttackRange && playerInSightRange)
        {
            isPatrolling = false;
            StopCoroutine(Patrol());
            AttackPlayer();
        }
    }

    private IEnumerator Patrol()
    {
        if (patrolPoints.Length == 0)
        {
            Debug.LogWarning("No patrol points assigned!");
            yield break;
        }

        while (true)
        {
            if (!isWaiting)
            {
                agent.SetDestination(patrolPoints[currentPatrolIndex].position);

                // Check if the enemy has reached the patrol point
                float distanceToPatrolPoint = Vector3.Distance(transform.position, patrolPoints[currentPatrolIndex].position);
                if (distanceToPatrolPoint < 1.0f)
                {
                    isWaiting = true;
                    yield return new WaitForSeconds(timeBetweenPatrols);
                    isWaiting = false;

                    // Move to the next patrol point
                    currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
                }
            }
            yield return null;
        }
    }

    private void ChasePlayer()
    {
        pointLight.color = AfterDiscover;
        if (!detectplayer.isPlaying && issCD <= 0)
        {
            detectplayer.Play();
        }

        // 5 seconds cooldown
        if (issCD > 0)
        {
            issCD--;
            return;
        }
        else
        {
            issCD = 5;
        }

        agent.SetDestination(player.position);
        transform.LookAt(player);
    }

    private void AttackPlayer()
    {
        // Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        if (!damageSFX.isPlaying)
        {
            damageSFX.Play();
        }

        gameManager.BossTakeDamage(damage);
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}