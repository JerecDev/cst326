using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Text text;
    int score;
    public static float enemySpeed = 0;
    public float xSpeed;
    public float turnTime = 5f;
    private bool xMove = false;
    public GameObject bullet;
    Vector3 posChange = new Vector3(0f, 1.5f, 0f);

    void Update()
    {
        xSpeed = 5.0f;
        if(!xMove)
        {
            StartCoroutine(xMoveCo());
            if (gameObject.tag == "Shooter")
            {
                GameObject shot = Instantiate(bullet, gameObject.transform.position - posChange, Quaternion.identity);
                Destroy(shot, 4f);
            }
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        enemySpeed += 2.0f;
        ScoreManager.score += 10;
        if (gameObject.tag == "Shooter")
        {
            ScoreManager.score += 10;
        }
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }

    IEnumerator xMoveCo()
    {
        xMove = true;
        float time = 0.0f;

        while (time < turnTime)
        {
            time += Time.deltaTime;
            Vector2 movement = Vector2.zero;
            movement.y = (transform.up * Time.deltaTime * -enemySpeed).y;
            movement.x = (transform.right * Time.deltaTime * -xSpeed).x;
            movement = movement + (Vector2)(transform.position);
            GetComponent<Rigidbody2D>().MovePosition(movement);
            yield return null;
        }
        if (gameObject.tag == "Shooter")
        {
            GameObject shot = Instantiate(bullet, gameObject.transform.position - posChange, Quaternion.identity);
            Destroy(shot, 4f);
        }
        while (time > 0 - turnTime/2)
        {
            time -= Time.deltaTime;
            Vector2 movement = Vector2.zero;
            movement.y = (transform.up * Time.deltaTime * -enemySpeed).y;
            movement.x = (transform.right * Time.deltaTime * xSpeed).x;
            movement = movement + (Vector2)(transform.position);
            GetComponent<Rigidbody2D>().MovePosition(movement);
            yield return null;
        }
        xMove = false;
    }

}
