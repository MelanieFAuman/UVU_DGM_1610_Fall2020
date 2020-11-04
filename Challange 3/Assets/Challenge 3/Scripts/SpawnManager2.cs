using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager2 : MonoBehaviour
{
    public GameObject[] objectprefabs;

    private float spawnDelay = 2;
    private float spawnRate = 2;

    private PlayerControllerX playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", spawnDelay, spawnRate);
        playerControllerScript =
            GameObject.Find("Player").GetComponent<PlayerControllerX>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObject()
    {
        int objectindex = Random.Range(0, objectprefabs.Length);
        Vector3 SpawnPos = new Vector3(30, Random.Range(5, 15), 0);

        if (playerControllerScript.gameOver == false)
        {
            Instantiate(objectprefabs[objectindex], SpawnPos, objectprefabs[objectindex].transform.rotation);
        }
    }
}
