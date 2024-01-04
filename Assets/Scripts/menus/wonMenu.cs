using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class wonMenu : MonoBehaviour
{
    public void replayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    public void exitGame()
    {
        Debug.Log("Quit is happening");
        Application.Quit();
    }
}
