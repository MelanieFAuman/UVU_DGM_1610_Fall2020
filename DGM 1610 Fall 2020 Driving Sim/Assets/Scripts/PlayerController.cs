using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20;
        public float turnSpeed;

    public float horizontalInput;
    public float vetricalInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        vetricalInput = Input.GetAxis("Vertical");

        //moves the vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * vetricalInput);
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
    }
}
