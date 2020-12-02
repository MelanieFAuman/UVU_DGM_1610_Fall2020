using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject player;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        // Set enemy towards Player and chase
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(transform.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
       
    }

}
