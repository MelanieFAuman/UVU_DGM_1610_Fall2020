using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Experimental.XR.Interaction;

public class PlayerControllerX : MonoBehaviour
{
    //Basic movment
    public float speed = 10f;
    private Rigidbody playerRB;

    //Jump force
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;

    //Boundries
    private float zBound = 15;

    //gameover
    private bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        //Basic movment info
        playerRB = GetComponent<Rigidbody>();

        //Jump Force
        Physics.gravity *= gravityModifier;

    }

    // Update is called once per frame
    void Update()
    {
        //Basic movment
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * horizontalInput);
        transform.Translate(Vector3.left * Time.deltaTime * speed * verticalInput);

        //Boundries;
        //z
        if (transform.position.z < - zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }

        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }

        //Jump Force
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Jump Force constraint
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}
