using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMovement : MonoBehaviour
{
    public float ballSpeed = 10.0f;
    public Rigidbody rb;
    public int scoreL, scoreR = 0;
    public float x, y, z;
    public float zMovement = 7.5f;
    Vector3 start = new Vector3(0f, .5f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(-20f, 0, zMovement);
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.position.x > 15)
        {

            scoreL++;
            Debug.Log("Left has scored! Score: " + scoreL + " / " + scoreR);
            if (scoreL >= 11)
            {
                Debug.Log("Game over, Left Wins!!");
                scoreL = 0;
                scoreR = 0;
            }
            rb.position = start;
            zMovement *= -1;
            rb.velocity = Vector3.zero;
            rb.AddForce(20f, 0, zMovement);
        }

        if (rb.position.x < -15)
        {
            scoreR++;
            Debug.Log("Right has scored! Score: " + scoreL + " / " + scoreR);
            if (scoreR >= 11)
            {
                Debug.Log("Game Over, Right Wins!!");
                scoreL = 0;
                scoreR = 0;
            }
            rb.position = start;
            zMovement *= -1;
            rb.velocity = Vector3.zero;
            rb.AddForce(-20f, 0, zMovement);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        float increase = 2.5f;
        if (collision.gameObject.name == "PaddleLeft" || collision.gameObject.name == "PaddleRight")
        {
                rb.AddForce(rb.velocity * increase);
        }
    }
}
