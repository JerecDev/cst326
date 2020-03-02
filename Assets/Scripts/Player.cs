using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public GameObject bullet;

  public Transform shottingOffset;
    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space))
      {
        GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
        Destroy(shot, 4f);
      }

        Vector2 movement = Vector2.zero;
        float moveSpeed = 15.0f;

        if (Input.GetKey(KeyCode.A))
        {
            movement.x = (transform.right * Time.deltaTime * -moveSpeed).x;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement.x = (transform.right * Time.deltaTime * moveSpeed).x;
        }
        movement = movement + (Vector2)(transform.position);
        movement.y = -8.0f;
        GetComponent<Rigidbody2D>().MovePosition(movement);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }

}
