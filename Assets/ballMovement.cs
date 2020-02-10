using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMovement : MonoBehaviour
{
    public float ballSpeed = 10.0f;
    public Rigidbody rb;
    public int scoreL, scoreR, shield = 0;
    public float x, y, z;
    public float zMovement = 7.5f;
    float increase = 2.5f;
    Vector3 start = new Vector3(0f, .5f, 0f);
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
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

        if (rb.position.x == 0 && shield != 0)
        {
            shield--;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "PaddleLeft" || collision.gameObject.name == "PaddleRight")
        {
            audioSource.pitch = rb.velocity.x / 10;
            audioSource.Play();
            rb.AddForce(rb.velocity * increase);
        }
        if (collision.gameObject.name == "Cylinder")
        {
            shield = 3;
        }


    }
}
