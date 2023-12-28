using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void enterGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);    
    }

    public void exitGame()
    {
        Debug.Log("Quit is happening");
        Application.Quit();
    }
}
