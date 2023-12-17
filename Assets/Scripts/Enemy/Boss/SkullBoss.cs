using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using UnityEngine.AI;

public class SkullBoss : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public float health;




    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;
    public Transform bulletSpawnPoint;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.autoTraverseOffMeshLink = true; // Enable off-mesh link traversal
    }


    public List<PlayerCabinTrigger> cabinTriggers = new List<PlayerCabinTrigger>();


    private void Update()
    {
        // Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!agent.pathPending && agent.remainingDistance < 0.1f)
        {
            // Enemy has reached its destination, reset walkPointSet
            walkPointSet = false;
        }



        if (!IsPlayerInsideAnyCabin())
        {
            // Player is not inside the cabin, continue with the regular behavior
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
        else
        {
            // Player is inside the cabin, so the beast remains in patrolling mode
            Patroling();
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
        // Calculate random point in range
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
        // Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        //

        if (!alreadyAttacked)
        {
            transform.LookAt(player);
            // Attack code here
            Rigidbody rb = Instantiate(projectile, bulletSpawnPoint.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 5f, ForceMode.Impulse);

            // End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    // Method to check if the player is inside any cabin
    private bool IsPlayerInsideAnyCabin()
    {
        foreach (var cabinTrigger in cabinTriggers)
        {
            if (cabinTrigger.IsInsideCabin)
            {
                return true;
            }
        }
        return false;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}