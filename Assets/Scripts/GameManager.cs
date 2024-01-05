using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform player;
    public Ork Dessertboss;
    public Guardian Forestboss;
    //public IceDragon Iceboss;;
    //public GameObject DessertTeleporter;
    //public GameObject TutorialArena;
    public GameObject DessertArena;
    public GameObject ForestArena;
    public GameObject IceArena;


    //public GameObject DessertTeleporter;
    public GameObject ForestTeleporter;
    public GameObject IceTeleporter;
    public GameObject FinalTeleporter;

    public int arena;
    //1 = dessert, 2 = forest, 3 = ice, 4 =final

    private bool orkDefeated = false;
    private bool centaurDefeated = false;
    private bool dragonDefeated = false;

    void Start()
    {
        if (player == null || Dessertboss == null || ForestTeleporter == null)
        {
            Debug.LogError("Player, Boss, or Next Arena Position not set in the GameManager!");
        }
    }

    void Update()
    {
        OrkDefeated();
    }

    public void isOrkDefeated()
    {
        if (Dessertboss.Defeated)
        {
            Debug.Log("ORK is defeated!");
            orkDefeated = true;
        }
    }
    public void OrkDefeated()
    {
        isOrkDefeated();
        if (orkDefeated)
        {
            ForestArena.SetActive(true);
            ForestTeleporter.SetActive(true);
            orkDefeated = false;
            if (arena != 1)
            {
                DessertArena.SetActive(false);
            }
        }
    }


    public void CentaurDefeated(){
        isCentaurDefeated();
        if (centaurDefeated)
        {
            IceArena.SetActive(true);
            IceTeleporter.SetActive(true);
            centaurDefeated = false;
            if (arena != 2)
            {
                ForestArena.SetActive(false);
            }
        }
    }

    public void isCentaurDefeated()
    {
        if (Forestboss.Defeated)
        {
            Debug.Log("centaur is defeated!");
            centaurDefeated = true;
        }
    }
    


}
