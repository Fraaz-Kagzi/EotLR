using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armour : MonoBehaviour
{
    public Player player;
    public bool isPoisonArmour;
    public bool isSandArmour;
    public bool isFrostArmour;
    public bool isMovementArmour;
    public float armourHealth;


    // Start is called before the first frame update
    void Start()
    {
        noArmour();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void noArmour() {

        isPoisonArmour = false;
        isSandArmour = false;
        isFrostArmour = false;
        player.freezeProtection = 10;
        isMovementArmour = false;
        armourHealth = 0;
    }

    public void activatebaseFrostArmour()
    {
        noArmour();
        player.freezeProtection = 100;

    }
    public void activateFrostArmour()
    {
        noArmour();
        isFrostArmour = true;

    }

    public void activatebaseArmour()
    {
        noArmour();
        armourHealth = 50;
    }
    public void activateArmour()
    {
        noArmour();
        armourHealth = 150;
    }
   
    public void activateSandArmour()
    {
        noArmour();
        isSandArmour = true;
    }
    
    public void activatePoisonArmour()
    {
        noArmour();
        isPoisonArmour = true;
    }


    public void deactivateArmour()
    {
        noArmour();
    }
}
