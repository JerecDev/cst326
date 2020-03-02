using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public int hiScore;
    public string output;
    public Text scoreText;
    public Text hiText;

    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (score < 100 && score > 0)
        {
            output = "00";
            output += score.ToString();
            scoreText.text = output;
        }
        if (score > 100)
        {
            output = "0";
            output += score.ToString();
            scoreText.text = output;
        }
        if (score > 1000)
        {
            output = score.ToString();
            scoreText.text = output;
        }
        if (score > hiScore)
        {
            hiText.text = output;
        }
    }
}
