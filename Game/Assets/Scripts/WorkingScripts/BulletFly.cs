using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    private GameObject player;

    private Rigidbody2D bullet;

    private BoxCollider2D collider;

    bool testPositionPlayer = true;

    float sidePlayer;

    void Start()
    {
        player = GameObject.Find("Player");

        collider = gameObject.GetComponent<BoxCollider2D>();

        bullet = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (testPositionPlayer == true)
        {
            test();
        }

        if (bullet != null)
        {
            fly();
        }
     
    }

    void fly()
    {
        if (sidePlayer > 0)
        {
            bullet.velocity = new Vector2(15, 0);
        }
        else
        {
            bullet.velocity = new Vector2(-15, 0);
        }
    }

    void test()
    {
        testPositionPlayer = false;

        sidePlayer = player.transform.position.x - transform.position.x;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "KickPlayer")
        {
            Destroy(gameObject);
        }
    }

}
