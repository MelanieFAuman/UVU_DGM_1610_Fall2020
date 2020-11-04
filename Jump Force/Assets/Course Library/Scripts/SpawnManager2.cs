using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager2 : MonoBehaviour
{
    public GameObject[] objectprefabs;

    private float spawnDelay = 2;
    private float spawnRate = 1.5f;

    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", spawnDelay, spawnRate);
        playerControllerScript = 
            GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        int objectindex = Random.Range(0, objectprefabs.Length);
        Vector3 SpawnPos = new Vector3(0, Random.Range(5, 15), 0);

        if (playerControllerScript.gameOver == false)
        {
            Instantiate(objectprefabs[objectindex], SpawnPos, objectprefabs[objectindex].transform.rotation);
        }
    }
}
