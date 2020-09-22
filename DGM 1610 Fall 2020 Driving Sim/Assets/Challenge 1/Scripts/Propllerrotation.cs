using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propllerrotation : MonoBehaviour
{
    public float speed = 30;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rotation of propeller around local axis
        transform.Rotate(Vector3.forward * speed);
    }
}
