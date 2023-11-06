using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damageAmount = 10; // Adjust this as needed

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the bullet collided with the player
        if (collision.collider.CompareTag("Player"))
        {
            // Get the PlayerHealth script from the player GameObject
            Player player = collision.collider.GetComponent<Player>();

            // Check if the playerHealth component is found
            if (player != null)
            {
                // Apply damage to the player
                player.TakeDamage(damageAmount);
            }

            // Destroy the bullet
            Destroy(gameObject);
        }
    }
}
