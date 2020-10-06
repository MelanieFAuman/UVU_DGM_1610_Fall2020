using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //Items under Spawn Manager
    public GameObject[] animalPrefabs;

    //Spawning area
    private float spawnRangeX = 20;
    private float spawnPosZ = 30;

    //Start of stampede and spawn rate
    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        //Contiunous spawning of animals
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
     
      {
 
      }
    }
    // keeps spawing of animals to correct amount
    void SpawnRandomAnimal()
    {
        // Randomly gen. animal index and spawn position
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }

}
