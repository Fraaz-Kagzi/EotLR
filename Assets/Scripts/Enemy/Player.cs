using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour
{
     public static int maxHealth = 250;
    public static int stamina = 100;
    public static int currentHealth;
    public Healthbar healthBar; // Reference to the health bar script

    //stamina

    //currently equipped weapon
    public GameObject equippedWeapon;


    

    private void Start()
    {
        currentHealth = maxHealth;
    }

    //health
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.UpdateHealthBar(currentHealth, maxHealth);
        Debug.Log(currentHealth);


        // Check for player death
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Time.timeScale = 0; // Pause time;
    }


    public static int getHealth()
    {
        return currentHealth;
    }


}

