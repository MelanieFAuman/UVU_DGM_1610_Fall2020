using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //main body of player
    private Rigidbody playerRb;
    //fall rate for jump vs up ward force
    public float jumpForce = 10;
    public float gravityModifier;

    //stop repeatative jumping
    public bool isOnGround = true;

    //Losing game upon collision
    public bool GameOver;

    //jumping animation
    private Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Jumping and animation of character using space
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //when player jumps it will stop ability to jump
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
        }

    }
    private void OnCollisionEnter(Collision collision)
        //Reactivates isOnGround code
    {

        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        } else if(collision.gameObject.CompareTag("Obstacle"))
        {
            GameOver = true;
            Debug.Log("Game Over!");
        }
    }
}
