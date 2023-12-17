using UnityEngine;
using UnityEngine.SceneManagement;

public class TableInteraction : MonoBehaviour
{
    public Transform interactionPoint;
    public float interactionRadius = 2f;
    public string inventorySceneName = "ActiveInventory";
    private Vector3 playerPositionBeforeInventory;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteractWithTable();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            ReturnFromInventory();
        }

        // Set cursor visibility based on the current scene
        SetCursorVisibility();
    }

    private void SetCursorVisibility()
    {
        bool isInventorySceneActive = IsInventorySceneActive();

        Cursor.visible = isInventorySceneActive;
        Cursor.lockState = isInventorySceneActive ? CursorLockMode.None : CursorLockMode.Locked;
    }

    private void TryInteractWithTable()
    {
        Collider[] colliders = Physics.OverlapSphere(interactionPoint.position, interactionRadius);

        foreach (var collider in colliders)
        {
            // Check if the player is near the table
            if (collider.CompareTag("Player"))
            {
                // Save the player's position before going to the inventory
                playerPositionBeforeInventory = collider.transform.position;

                // Load the inventory scene additively
                SceneManager.LoadScene(inventorySceneName, LoadSceneMode.Additive);
                break; // Exit the loop after finding the player
            }
        }
    }

    private void ReturnFromInventory()
    {
        // Check if the current scene is the inventory scene
        Scene currentScene = SceneManager.GetSceneByName(inventorySceneName);
        if (currentScene.isLoaded)
        {
            Debug.Log("Returning from inventory...");

            // Return to the position before going to the inventory
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                player.transform.position = playerPositionBeforeInventory;
                Debug.Log("Player returned to the original position.");
            }

            // Unload the inventory scene
            SceneManager.UnloadSceneAsync(inventorySceneName);
            Debug.Log("Unloaded InventoryScene.");
        }
    }

    private bool IsInventorySceneActive()
    {
        // Check if the inventory scene is active by checking its build index
        Scene currentScene = SceneManager.GetActiveScene();
        Scene inventoryScene = SceneManager.GetSceneByName(inventorySceneName);
        return currentScene.buildIndex == inventoryScene.buildIndex;
    }
}
