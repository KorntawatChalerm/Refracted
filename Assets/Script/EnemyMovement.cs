using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private int speed;


    private Rigidbody2D rb2d;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        Vector2 vel = new Vector2(0, rb2d.velocity.y);

        if (transform.localScale.x < 0)
        {

            vel.x = -speed;
            //some variable = minus
        }
        else
        {

            vel.x = speed;
            //some variable = plus

        }

        rb2d.velocity = vel;



    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //player die
            GameManager.instance.isdead = true;
        }/*if (collision.CompareTag("EndChase"))
        {
            //end chase
            GameManager.instance.isdead = false;
        }*/
    }
}
