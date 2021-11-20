using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFastLeft : MonoBehaviour
{
    Vector2 impulseL = new Vector2(-100, 180);
    private Rigidbody2D player;
    Vector2 impulseR = new Vector2(70, 150);

    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }
    void impulseLeft()
    {
        player.constraints = RigidbodyConstraints2D.FreezeRotation;

        player.velocity = new Vector2(0, 0);

        player.AddForce(impulseL, ForceMode2D.Impulse);
    }

    void impulseRight()
    {
        player.constraints = RigidbodyConstraints2D.FreezeRotation;

        player.velocity = new Vector2(0, 0);

        player.AddForce(impulseR, ForceMode2D.Impulse);
    } 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy" && collision.gameObject.transform.position.x < gameObject.transform.position.x)
        {
            impulseRight();
        }

        if (collision.gameObject.tag == "enemy" && collision.gameObject.transform.position.x > gameObject.transform.position.x)
        {
            impulseLeft();
        }

    }




}
