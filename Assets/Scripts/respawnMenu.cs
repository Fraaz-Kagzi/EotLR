using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class respawnMenu : MonoBehaviour
{
    public void respawnGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
