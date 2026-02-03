using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform player;
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject projectilePrefab;

    [Header("Layers")]
    [SerializeField] private LayerMask terrain;
    [SerializeField] private LayerMask playerrLayerMask;

    [Header("Patroling")]
    [SerializeField] private float patrolRadius = 10f;
    private Vector3 walkPoint;
    private bool hasPatrolPoint;

    [Header("Attacking")]
    [SerializeField] private float attackCooldown = 1f;
    private bool isOnAttackCooldown;
    [SerializeField] private float forwardShotForce = 10f;
    [SerializeField] private float verticalShotForce = 5f;

    [Header("Detection Ranges")]
    [SerializeField] private float visionRange = 20f;
    [SerializeField] private float engagementRange = 10f;

    private bool isPlayerVisible;
    private bool isPlayerInRange;


    private void Awake()
    {
        if (player == null)
        {
            GameObject playerObj = GameObject.Find("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
            }
            else
            {
                Debug.LogError("EnemyAi: No GameObject with tag 'Player' found in the scene.");
            }
        }
        if (agent == null)
        {
            agent = GetComponent<NavMeshAgent>();
            if (agent == null)
            {
                Debug.LogError("EnemyAi: No NavMeshAgent component found on this GameObject.");
            }
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        DetectPLayer();
        UpdateBehaviourState();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, engagementRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRange);
    }

    private void DetectPLayer()
    {
        isPlayerVisible = Physics.CheckSphere(transform.position, visionRange, playerrLayerMask);
        isPlayerInRange = Physics.CheckSphere(transform.position, engagementRange, playerrLayerMask);
    }

    private void FireProjectile()
    {
        if (projectilePrefab == null || firepoint == null) return;
        Rigidbody projectileRb = Instantiate(projectilePrefab, firepoint.position, Quaternion.identity).GetComponent<Rigidbody>();
        projectileRb.AddForce(transform.forward * forwardShotForce, ForceMode.Impulse);
        projectileRb.AddForce(transform.up * verticalShotForce, ForceMode.Impulse);

        Destroy(projectileRb.gameObject, 3f);
    }

    private void FindPatrolPoint()
    {
        float randomZ = Random.Range(-patrolRadius, patrolRadius);
        float randomX = Random.Range(-patrolRadius, patrolRadius);
        Vector3 potentialPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(potentialPoint, -transform.up, 2f, terrain))
        {
            walkPoint = potentialPoint;
            hasPatrolPoint = true;
        }
    }

    private IEnumerator AttackCooldownRoutine()
    {
        isOnAttackCooldown = true;
        yield return new WaitForSeconds(attackCooldown);
        isOnAttackCooldown = false;
    }

    private void PerformPatrol()
    {
        if(!hasPatrolPoint)
            FindPatrolPoint();

        if(hasPatrolPoint)
            agent.SetDestination(walkPoint);

        if(Vector3.Distance(transform.position, walkPoint) < 1f)
            hasPatrolPoint = false;
    }

    private void PerformChase()
    {
        if(player != null)
        {
            agent.SetDestination(player.position);
        }
    }

    private void PerformAttack()
    {
        agent.SetDestination(transform.position);

        if (player != null)
        {
            transform.LookAt(player);
        }

        if(!isOnAttackCooldown)
        {
            FireProjectile();
            StartCoroutine(AttackCooldownRoutine());
        }
    }

    private void UpdateBehaviourState()
    {
        if (!isPlayerVisible && !isPlayerInRange)
        {
            PerformPatrol();
        }
        else if (isPlayerVisible && !isPlayerInRange)
        {
            PerformChase();
        }
        else if (isPlayerInRange & isPlayerVisible)
        {
            PerformAttack();
        }
    }
}

    
