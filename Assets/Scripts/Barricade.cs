using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : MonoBehaviour
{

    public GameObject barricade;
    private Rigidbody2D myRigidbody2D;
    Vector2 currentPos = Vector2.zero;
    Vector3 scaleChange = new Vector3(0f, .5f, 0f);
    float scale = 1.0f;

    void Start()
    {
        //GameObject barricade1 = Instantiate(barricade, new Vector2(9.0f, 6.5f), Quaternion.identity) as GameObject;
        //myRigidbody2D = GetComponent<Rigidbody2D>();
        currentPos = gameObject.transform.localPosition;
    }

    void Update()
    {
        gameObject.transform.position = currentPos;
        gameObject.transform.rotation = Quaternion.identity;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        Destroy(collision.gameObject);
        if (scale == 1.0f)
        {
            scale = 0.5f;
            gameObject.transform.localScale -= scaleChange;
            return;
        }
        if (scale == 0.5f)
        {
           Destroy(gameObject);
        }
    }
}
