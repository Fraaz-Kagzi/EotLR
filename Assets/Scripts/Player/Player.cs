using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;



public class Player : MonoBehaviour
{
    public static int maxHealth = 250;
    public CoinManager coinManager;


    public  int realmGold;
    public static int stamina = 100;
    public static int currentHealth;
    public Healthbar healthBar; // Reference to the health bar script

    public TextMeshProUGUI text;

    //currently equipped weapon
    public GameObject equippedWeapon;


    

    private void Start()
    {
        int coins = CoinManager.playerCoins;
        realmGold=coins;
        currentHealth = maxHealth;
    }
    private void Update(){
        text.SetText("RealmGold: §"+ realmGold);
       
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

    public void addRealmGold(int value){
        CoinManager.addCoins(value);
        int coins = CoinManager.playerCoins;
        realmGold=coins;
    }


    public static int getHealth()
    {
        return currentHealth;
    }




}

