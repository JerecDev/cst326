using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickDestroy : MonoBehaviour
{
    public int health = 3;
    public int coinsTotal;
    public Text coins;

    void Start()
    {
        coins = GameObject.Find("coinsTotal").GetComponent<Text>();
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                BoxCollider boxCollider = hit.collider as BoxCollider;
                if (boxCollider.tag != null)
                {
                    if (health == 0)
                    {
                        Destroy(boxCollider.gameObject);
                        health = 3;
                        coinsTotal++;
                        coins.text = "" + coinsTotal;
                    }
                    health--;
                }
            }
        }
    }
}
