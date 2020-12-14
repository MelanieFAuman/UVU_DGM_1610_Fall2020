using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSystem : MonoBehaviour
{
    public GameObject point;
    public int regen = 1;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(point, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().health += regen;
            Debug.Log(other.GetComponent<PlayerController>().health);
        }
    }
}
