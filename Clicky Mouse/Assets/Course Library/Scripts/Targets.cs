using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour
{
    private Rigidbody targetRb;

    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -4;

    //Score counting
    private GameManager gameManager;

    //Target Value
    public int pointValue;

    //Animations
    public ParticleSystem explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        // Random Positions and Hieght
        targetRb = GetComponent<Rigidbody>();

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPos();

        //counting score
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Used to create random spawnig and clean up
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }


    //Destroy objects
    private void OnMouseDown()
    {
        //Game Over
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);

            //Animation
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);

            //Counting score
            gameManager.UpdateScore(pointValue);

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }
}
