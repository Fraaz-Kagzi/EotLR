using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Player player;
    //enemy stats
    public int health = 100;
    public int maxHealth = 100;

    // value of each enemy CoinManager
    public int value;
    
    public EnemyHealthBar healthBar; // Reference to the health bar script

    private void Awake()
    {
        healthBar = GetComponentInChildren<EnemyHealthBar>();
    }
    private void Start()
    {

        health = maxHealth;
    }





    // Called when the enemy is shot
    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.UpdateHealthBar(health, maxHealth);
        Debug.Log(health);

        if (health <= 0)
        {
          

            Debug.Log("Enemy is destroyed!");
            // Enemy is "destroyed" by deactivating it
            gameObject.SetActive(false);

            // Re-enable the enemy after a delay
            player.addRealmGold(value);
            Invoke("Respawn", 2f);
        }
        Debug.Log(player.realmGold);
        
    }

    // Called to respawn the enemy
    void Respawn()
    {
        // Reset health and reactivate the enemy
        health = 100;
        healthBar.SetHealth(100, 100);
        Debug.Log(health);
        gameObject.SetActive(true);
    }
}
