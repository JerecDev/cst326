using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour
{
    float timeLeft = 400.0f;
    public Text text;

    void Update()
    {
        timeLeft -= Time.deltaTime;
        text.text = "" + Mathf.Round(timeLeft);
    }
}