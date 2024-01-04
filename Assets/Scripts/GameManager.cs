using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform player;
    public Ork Dessertboss;
    //public GameObject DessertTeleporter;
    public GameObject DessertArena;
    public GameObject ForestTeleporter;
    public int arena;
    //1 = dessert, 2 = forest, 3 = ice, 4 =final

    private bool orkDefeated = false;

    void Start()
    {
        if (player == null || Dessertboss == null || ForestTeleporter == null)
        {
            Debug.LogError("Player, Boss, or Next Arena Position not set in the GameManager!");
        }
    }

    void Update()
    {
        ORKDefeated();
        if (orkDefeated)
        {
            Debug.Log("Boss Defeated! Teleporting player...");
            ForestTeleporter.SetActive(true);
            orkDefeated = false;
            if(arena != 1)
            {
                DessertArena.SetActive(false);
            }
        }
    }

    public void ORKDefeated()
    {
        if (Dessertboss.Defeated)
        {
            Debug.Log("ORK is defeated!");
            orkDefeated = true;
        }
    }

    
}
