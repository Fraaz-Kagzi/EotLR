using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCabinTrigger : MonoBehaviour
{
    private bool isInsideCabin = false;

    public bool IsInsideCabin => isInsideCabin;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInsideCabin = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInsideCabin = false;
        }
    }
}

