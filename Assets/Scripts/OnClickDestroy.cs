using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickDestroy : MonoBehaviour
{
    public int health = 3;
    public int coinsTotal;
    public Text coins;
    public Slider healthBar;
    public GameObject defense;

    void Start()
    {
        coins = GameObject.Find("coinsTotal").GetComponent<Text>();
        healthBar = GameObject.Find("SliderHealth").GetComponent<Slider>();
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 wordPos;
            if (Physics.Raycast(ray, out hit))
            {
                BoxCollider boxCollider = hit.collider as BoxCollider;
                if (boxCollider.tag != null && boxCollider.tag != "placeholder")
                {
                    if (health == 0)
                    {
                        Destroy(boxCollider.gameObject);
                        health = 3;
                        coinsTotal++;
                        coins.text = "" + coinsTotal;
                    }
                    health--;
                    healthBar.value -= .3f;
                }
                if (boxCollider.tag == "placeholder")
                {
                    if(coinsTotal == 0)
                    {
                        Debug.Log("Not enough coins to place defenses");
                    }
                    else
                    {
                        wordPos = hit.point;
                        Instantiate(defense, wordPos, Quaternion.identity);
                        coinsTotal--;
                        coins.text = "" + coinsTotal;
                    }

                }
            }
        }
    }
}

