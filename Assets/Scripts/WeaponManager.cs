using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject[] guns;
    private void Start()
    {
        LoadWeapon();
    }
    private void Update()
    {
        Debug.Log("Gun is " + guns);
    }

    public void LoadWeapon()
    {
        for(int i= 0; i<guns.Length; i++){
            if(guns[i].name ==  InventoryManager.equipedWeapon)
            {
                guns[i].SetActive(true);
            }

        }

    }
}
