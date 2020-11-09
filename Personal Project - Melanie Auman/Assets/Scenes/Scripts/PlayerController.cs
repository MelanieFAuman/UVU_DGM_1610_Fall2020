using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;

    //Movement;
    //Speed
    public float speed = 10f;
    public float xRange = 20;
    public float turnspeed = 100;
    //X and Z inputs
    private float horizontalInput;
    private float verticalInput;

    //jumping ablitiy
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;

    //Game Over and Death
    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        //Jump Force
        playerRB = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //X Y Movement based on input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * horizontalInput);
        transform.Rotate(Vector3.up, turnspeed * verticalInput * Time.deltaTime);

        //Jump Force
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    //detect ground
    private void OnCollisionEnter(Collision collision)
    {
        //Jump on Ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}
