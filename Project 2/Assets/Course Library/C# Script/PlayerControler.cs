using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float horizontalinput;
    public float speed = 10f;
    public float xRange = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalinput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * horizontalinput * Time.deltaTime * speed);

        if(transform.position.x < -xRange);
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange);
        {
            transform.position = new Vector3(10, transform.position.y, transform.position.z);
        }
    }
}
