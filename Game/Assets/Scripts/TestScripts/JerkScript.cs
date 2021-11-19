using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JerkScript : MonoBehaviour
{    public Rigidbody2D player;
     public static int jerkSum = 1;
     public static int testRotation = 1;
    Vector2 jerkPos = new Vector2(30, 0);

    Vector2 stopJerk = new Vector2(0, -3);

    float playerX;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            player.velocity = new Vector2(0, 12);
        }
    }

    public void jerk()
    {
        if (testRotation == 1)
        {


            playerX = player.position.x;

            player.constraints = RigidbodyConstraints2D.FreezePositionY;

            player.velocity = jerkPos;
        }

        if (testRotation == 0)
        {


            playerX = player.position.x;

            player.constraints = RigidbodyConstraints2D.FreezePositionY;

            player.velocity = -jerkPos;
        }

    }

    private void Update()
    {
        if((playerX != 0 && player.position.x - playerX > 10) || (playerX != 0 && player.position.x - playerX < -10))
        {
            player.constraints = RigidbodyConstraints2D.None;
            
            player.velocity = stopJerk;

            playerX = 0;
        }
    }
}
