using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CubeDestroyer : MonoBehaviour
{
    public Text scoreText;
    public Text coinText;
    public int points = 0;
    public int coins = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                BoxCollider boxCollider = hit.collider as BoxCollider;

                if (boxCollider.tag != null)
                    Destroy(boxCollider.gameObject);

                if (boxCollider.tag == "qbox")
                {
                    Destroy(boxCollider.gameObject);
                    coins++;
                    coinText.text = "Coins x " + coins;
                }
            }
        }
    }
}
