using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JerkScript : MonoBehaviour
{
    private Rigidbody2D player;
    public static int jerkSum = 1;
    public static int testRotation = 1;
    Vector2 stopJerk = new Vector2(0, -3);

    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }
    private IEnumerator jerkCorutine()
    {
        if (jerkSum == 0)
        {
            yield return new WaitForSeconds(0.15f);

            jerkSum = 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


        if(collision.gameObject.tag == "enemy")
        {
            if (testRotation == 1)
            {



                StopAllCoroutines();

                player.constraints = RigidbodyConstraints2D.FreezeRotation;

                player.velocity = new Vector2(0, 0);

                player.AddForce(new Vector2(-90, 150), ForceMode2D.Impulse);
            }
            else
            {
                StopAllCoroutines();

                player.constraints = RigidbodyConstraints2D.FreezeRotation;

                player.velocity = new Vector2(0, 0);

                player.AddForce(new Vector2(90, 150), ForceMode2D.Impulse);
            }
        }
    }

   
       
    

    private IEnumerator stopJerkCor()
    {
        yield return new WaitForSeconds(0.5f);

        player.constraints = RigidbodyConstraints2D.FreezeRotation;

        player.velocity = stopJerk;

        print("go down");
    }

    
    

    public void jerk()
    {
        Vector2 jerkPos = new Vector2(30, 0);

        if (testRotation == 0)
            jerkPos = -jerkPos;


        if (jerkSum == 1)
        { 
            print("you do jerk");

            StartCoroutine(stopJerkCor());

            player.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;

            player.velocity = jerkPos;

            jerkSum = 0;
        }

        if(jerkSum == 0)
        {

            StartCoroutine(jerkCorutine());

        }
    }

   

    private void Update()
    {
    }
}
