using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperScope : MonoBehaviour
{
    
    public Camera scopeCamera; // Reference to the scope camera
    public bool zoomed;
  
    
    private void Start()
    {
        

        zoomed = false;
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            zoomed = true;
            ToggleScope();
        }
        if (Input.GetKeyUp(KeyCode.Mouse1) && zoomed)
        {
            UnToggleScope();
            zoomed = false;
           
        }

    }

    private void ToggleScope()
    {
        scopeCamera.fieldOfView=9;

        
    }
    private void UnToggleScope()
    {
        scopeCamera.fieldOfView = 60;


    }
}
