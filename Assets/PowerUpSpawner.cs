using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject powerUpPrefab;
    private GameObject savedPrefab;
    private Transform pos;
    private Coroutine c_Spawning;

    private void Start()
    {
        savedPrefab = Instantiate(powerUpPrefab, transform);
    }
    private void Update()
    {
        Debug.Log(savedPrefab);
        if (savedPrefab == null && c_Spawning == null)
        {
            c_Spawning = StartCoroutine(SpawnPowerUp());
        }
    }

    private IEnumerator SpawnPowerUp()
    {
        Debug.Log("Hello we in here");
        yield return new WaitForSeconds(5f);
        
        savedPrefab = Instantiate(powerUpPrefab, transform);
        c_Spawning = null;
    }

}
