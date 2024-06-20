using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsManager : MonoBehaviour
{
    public GameObject platformPrefab;
    public Vector3 spawnPosition;
    public float respawnDelay = 5f;

    public void RespawnPlatform()
    {
        StartCoroutine(RespawnAfterDelay(respawnDelay));
    }

    private IEnumerator RespawnAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
    }
}
