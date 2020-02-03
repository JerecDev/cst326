using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour
{
    GameObject leftPaddle, rightPaddle;
    // Start is called before the first frame update
    void Start()
    {
        leftPaddle = GameObject.Find("PaddleLeft");
        rightPaddle = GameObject.Find("PaddleRight");
    }

    // Update is called once per frame
    float paddleSpeed = 10f;
    void Update()
    {

        if (Input.GetKey(KeyCode.UpArrow))
            rightPaddle.transform.Translate(Vector3.forward * Time.deltaTime * paddleSpeed);

        if (Input.GetKey(KeyCode.DownArrow))
           rightPaddle.transform.Translate(-1 * Vector3.forward * Time.deltaTime * paddleSpeed);

        if (Input.GetKey(KeyCode.W))
            leftPaddle.transform.Translate(Vector3.forward * Time.deltaTime * paddleSpeed);

        if (Input.GetKey(KeyCode.S))
            leftPaddle.transform.Translate(-1 * Vector3.forward * Time.deltaTime * paddleSpeed);

    }
}
