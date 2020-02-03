using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMovement : MonoBehaviour
{
    public float ballSpeed = 10.0f;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    bool start = true;
    void Update()
    { 

        rb.velocity = Vector3.left * ballSpeed;
    }
}
