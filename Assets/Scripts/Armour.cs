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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void noArmour() {
        
    }

    public void activatebaseFrostArmour()
    {
        player.freezeProtection = 100;

    }
    public void deactivatebaseFrostArmour()
    {
        player.freezeProtection = 100;

    }
    public void activateFrostArmour()
    {
        isFrostArmour = true;

    }
    public void deactivateFrostArmour()
    {
        isFrostArmour = false;

    }

    public void activateSandArmour()
    {
        isSandArmour = true;
    }
    public void deactivateSandArmour()
    {
        isSandArmour = false;
    }
    public void activatePoisonArmour()
    {
        isPoisonArmour = true;
    }
    public void deactivatePoisonArmour()
    {
        isPoisonArmour = false;
    }
}
