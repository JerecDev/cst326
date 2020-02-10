using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ballMovement : MonoBehaviour
{
    public float ballSpeed = 10.0f;
    public Rigidbody rb;
    public string lastHit = "";
    public int scoreL, scoreR = 0;
    public float x, y, z;
    public float zMovement = 7.5f;
    float increase = 2.5f;

    public Text scoreboard;


    GameObject leftPaddle, rightPaddle;
    Vector3 start = new Vector3(0f, .5f, 0f);
    AudioSource audioSource;
    Vector3 scaleChange = new Vector3(0f, 0f, .5f);


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb.AddForce(-20f, 0, zMovement);
        leftPaddle = GameObject.Find("PaddleLeft");
        rightPaddle = GameObject.Find("PaddleRight");
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.position.x > 15)
        {

            scoreL++;
            scoreboard.text = "";
            scoreboard.color = new Color(0, 0, 0, 1);
            scoreboard.text += scoreL + " : " + scoreR;
            if (scoreL >= 11)
            {
                scoreboard.color = new Color(1, 0, 0, 1);
                scoreboard.text = "Game Over, Left Wins!!";
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
            scoreboard.text = "";
            scoreboard.color = new Color(0, 0, 0, 1);
            scoreboard.text += scoreL + " : " + scoreR;
            if (scoreR >= 11)
            {
                scoreboard.color = new Color(1, 0, 0, 1);
                scoreboard.text = "Game Over, Right Wins!!";
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
        if (collision.gameObject.name == "PaddleLeft" || collision.gameObject.name == "PaddleRight")
        {
            if (collision.gameObject.name == "PaddleRight")
            {
                audioSource.pitch = rb.velocity.x / -7;
                lastHit = "right";
            }
            else
            {
                audioSource.pitch = rb.velocity.x / 7;
                lastHit = "left";
            }
            audioSource.Play();
            rb.AddForce(rb.velocity * increase);
        }
        if (collision.gameObject.name == "Cylinder")
        {
            if (lastHit == "left")
            {
                leftPaddle.transform.localScale += scaleChange;
                rightPaddle.transform.localScale -= scaleChange;
            }
            if (lastHit == "right")
            {
                rightPaddle.transform.localScale += scaleChange;
                leftPaddle.transform.localScale -= scaleChange;
            }
        }


    }
}
