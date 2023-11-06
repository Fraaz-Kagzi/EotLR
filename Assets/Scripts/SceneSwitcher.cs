using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string shopSceneName = "ShopScene";

    private bool inShopScene = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!inShopScene)
            {
                SceneManager.LoadScene(shopSceneName, LoadSceneMode.Additive);
                inShopScene = true;
            }
        
        }
        if (Input.GetKeyDown(KeyCode.Escape)){
            if(inShopScene)
            {
                SceneManager.UnloadSceneAsync(shopSceneName);
                inShopScene = false;
            }

        }

        
    }
}

