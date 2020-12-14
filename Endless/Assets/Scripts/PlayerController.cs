using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    private Vector3 targetPos;
    public float Ymovement;

    public float maxHeight;
    public float minHeight;

    public int health = 3;

    private GameManager gameManager;

    public GameObject effect;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
            Instantiate(effect, transform.position, effect.transform.rotation);

            gameManager.GameOver();
        }
    }

}
