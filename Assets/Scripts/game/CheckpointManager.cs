using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CheckpointManager : MonoBehaviour
{
    private static Transform respawnPoint;

    public static void SetRespawnPoint(Transform checkpoint)
    {
        respawnPoint = checkpoint;
        Debug.Log("RESPAWN SET");
    }

    public static Transform GetRespawnPoint()
    {
        return respawnPoint;
    }
}
