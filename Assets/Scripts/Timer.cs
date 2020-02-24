using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour
{
    float timeLeft = 100.0f;
    public Text text;

    void Start()
    {
    }

    void Update()
    {
        
        timeLeft -= Time.deltaTime;
        text.text = "" + Mathf.Round(timeLeft);
        if (timeLeft < 0)
        {
            Debug.Log("Times up, game over!");
        }
        
    }
}