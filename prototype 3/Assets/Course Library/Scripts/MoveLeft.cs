using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30;

    //end movement upon gameover
    private PlayerController playerControllerScript;

    //Destroy Out of Bound objects
    private float leftBound = -15;

    // Start is called before the first frame update
    void Start()
    {
        //collison of player reading
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Stopped moving left upon gameover
        if (playerControllerScript.GameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
