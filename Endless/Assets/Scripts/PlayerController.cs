using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Vector3 targetPos;
    public float Ymovement;

    public float maxHeight;
    public float minHeight;

    public int health = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight)
        {
            targetPos = new Vector3(transform.position.x, transform.position.y + Ymovement);
            transform.position = targetPos;
        }
      else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight)
        {
            targetPos = new Vector3(transform.position.x, transform.position.y - Ymovement);
            transform.position = targetPos;
        }

      //Game over
      if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
    }
}
