using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    private GameObject player;

    private Rigidbody2D bullet;

    bool testPositionPlayer = true;

    float sidePlayer;

    void Start()
    {
        player = GameObject.Find("Player");

        bullet =gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(testPositionPlayer == true)
        {
            test();
        }

        if(bullet != null)
        {
            fly();
        }

        
    }


    void fly()
    {
        if (sidePlayer > 0)
        {
            bullet.velocity = new Vector2(10, 0);
        }
        else
        {
            bullet.velocity = new Vector2(-10, 0);
        }
    }

    void test()
    {
        testPositionPlayer = false;

        sidePlayer = player.transform.position.x - transform.position.x;
    }

}
