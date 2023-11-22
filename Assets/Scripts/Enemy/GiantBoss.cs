using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GiantBoss : MonoBehaviour
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


//States
public float sightRange, attackRange;
public bool playerInSightRange, playerInAttackRange;



private void Awake()
{
    player = GameObject.Find("Player").transform;
    agent = GetComponent<NavMeshAgent>();
}

private void Update()
{
    //Check for sight and attack range
    playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
    playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) {

            GetComponent<Animator>().SetBool("isAttacking", false);
            GetComponent<Animator>().SetBool("isMoving", true);
            Patroling();
            

        }
        if (playerInSightRange && !playerInAttackRange) {
            GetComponent<Animator>().SetBool("isAttacking", false);
            GetComponent<Animator>().SetBool("isMoving", true);
            ChasePlayer();
            

        }
        if (playerInAttackRange && playerInSightRange)
        {
            
            GetComponent<Animator>().SetBool("isAttacking", true);
            AttackPlayer();
            



        }
    }

private void Patroling()
{
    if (!walkPointSet) SearchWalkPoint();

    if (walkPointSet)
        agent.SetDestination(walkPoint);

    Vector3 distanceToWalkPoint = transform.position - walkPoint;

    //Walkpoint reached
    if (distanceToWalkPoint.magnitude < 1f)
        walkPointSet = false;
}
private void SearchWalkPoint()
{
    //Calculate random point in range
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
    //Make sure enemy doesn't move
    agent.SetDestination(transform.position);

    transform.LookAt(player);

    if (!alreadyAttacked)
    {
            ///Attack code here
            PerformPhysicalAttack();
        ///End of attack code

        alreadyAttacked = true;
        Invoke(nameof(ResetAttack), timeBetweenAttacks);
    }
}
private void ResetAttack()
{
    alreadyAttacked = false;
}

void PerformPhysicalAttack()
{
    // For a giant boss, a simple melee attack animation or effect could be triggered here
    // You can also add damage calculation and other effects

    // Example: Set the "isAttacking" parameter in the Animator
    

    // Example: Deal damage to the player (assuming the player has a health component)
    Player playerHealth = player.GetComponent<Player>();
    if (playerHealth != null)
    {
        playerHealth.TakeDamage(10); // Adjust the damage value as needed
    }
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
}