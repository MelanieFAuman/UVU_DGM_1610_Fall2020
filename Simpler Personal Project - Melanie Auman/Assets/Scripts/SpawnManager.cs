using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    public GameObject shieldPrefab;
    public GameObject lifePrefab;

    private float spawnRangeX = 50;
    private float spawnZMin = -20;
    private float spawnZMax = 20;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Generate random spawn position for powerups and obstacles
    Vector3 GenerateSpawnPosition ()
    {
        float xPos = Random.Range(-spawnRangeX, spawnRangeX);
        float zPos = Random.Range(spawnZMin, spawnZMax);
        return new Vector3(xPos, 0, zPos);
    }
}
