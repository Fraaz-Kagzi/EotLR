using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class DragonBoss : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public float health;
    bool isPerformingSpecialAttack;
    bool isFlying = false; // Added state for flying

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    public float landingRange ; // Set your desired landing range here

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange, airSightRange, airAttackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        // Check if the dragon is flying
        isFlying = DragonIsFlying();
        Debug.Log(isFlying);
        Debug.Log(Vector3.Distance(transform.position, player.position));

        if (isFlying)
        {
            // Handle flying behavior
            HandleFlyingBehavior();
        }
        else
        {
            // Handle ground behavior
            HandleGroundBehavior();
        }
    }

    private void HandleGroundBehavior()
    {
        // Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
            GetComponent<Animator>().SetBool("isMoving", true);
            Patroling();
        }
        else if (playerInSightRange && !playerInAttackRange)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
            GetComponent<Animator>().SetBool("isMoving", true);
            ChasePlayer();
        }
        else if (playerInAttackRange && playerInSightRange)
        {
            GetComponent<Animator>().SetBool("isAttacking", true);
            AttackPlayer();
        }
    }

    

    private void HandleFlyingBehavior()
    {
        // Implement custom flying movement logic here
        // For example, use rigidbody.AddForce or transform.Translate
        // ...

        // Check for sight and attack range in the air
        playerInSightRange = Physics.CheckSphere(transform.position, airSightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, airAttackRange, whatIsPlayer);

        // Check for landing range
        bool inLandingRange = Vector3.Distance(transform.position, player.position) < landingRange;

        if (inLandingRange)
        {
            // Set animator bool for landing
            GetComponent<Animator>().SetBool("isLanding", true);
            // Additional logic for landing animation

            // You may want to add a delay before transitioning to ground behavior
            //StartCoroutine(DelayedTransitionToGroundBehavior());
        }
        else
        {
            GetComponent<Animator>().SetBool("isLanding", false);
        }
    }

    


    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        // Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            // Attack code here
            // PerformPhysicalAttack(); // Uncomment if you want to use your existing attack logic
            // ...

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    // Additional methods...

    private bool DragonIsFlying()
{
    // Check if the dragon's y position is greater than -5
    return transform.position.y > -20f;
}

}
