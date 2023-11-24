using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public EnemyCounterUI enemyCounter;
    public GameObject bossPrefab; // Reference to the boss (Ork) prefab
    public int totalEnemies = 10;

    
    

    public void EnemyKilled()
    {
        totalEnemies--;
        enemyCounter.UpdateEnemyCount(totalEnemies);




        if (totalEnemies <= 0)
        {
            // Activate the boss (Ork)
            
            Invoke("ActivateBoss", 1f);
        }
    }

    void ActivateBoss()
    {
        bossPrefab.SetActive(true);

    }
}