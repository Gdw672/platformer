using System.Collections;
using System.Collections.Generic;
using UnityEngine;




    public class enemyBehaviotLong : MonoBehaviour
    {
    private Rigidbody2D physic;

    public Transform player;

    public float speed;

    public float agroDistance;

    public GameObject bullet;

    public bool barier;

    private bool testVector;

    private bool testCor;
    private bool afterKickPlayer;

    private Vector2 fr = new Vector2(70, 50);

    private void Start()
    {
        physic = gameObject.GetComponent<Rigidbody2D>();

        barier = true;

        testVector = true;

        testCor = true;

        afterKickPlayer = true;
}

    
    private void Update()
    {
        if(player != null )
        {
            float destToPlayer = Vector2.Distance(transform.position, player.position);

            if (destToPlayer < agroDistance)
            {
                if(barier == true)
                startHunting();
            } 
        }
        movement();
    }

    
    void startHunting()
    {
        print("Start Hunt");

        StartCoroutine("createBullet");
    }

    void movement()
    {
        StartCoroutine("testTimeForMove");
        if(testVector == true && afterKickPlayer == true)
        {
            physic.velocity = new Vector2(3, 0);
        }

        if (testVector == false && afterKickPlayer == true)
            physic.velocity = new Vector2(-3, 0);
    }

    IEnumerator testTimeForMove()
    {
        if (testCor == true && afterKickPlayer == true)
        {
            testCor = false;

            yield return new WaitForSeconds(2);

            if (testVector == true)
                testVector = false;
            else
                testVector = true;

            testCor = true;

            print(testCor);
        }
    }
   

    IEnumerator createBullet()
    {
        GameObject clone;

        barier = false;

        System.Random randomTime = new System.Random();

        float rnd = randomTime.Next(1, 4);

       yield return new WaitForSeconds(rnd);

       clone = GameObject.Instantiate(bullet);

        clone.tag = "bullet";

        clone.transform.position = gameObject.transform.position;

        barier = true;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "KickPlayer")
        {
            afterKickPlayer = false;

            StopCoroutine("testTimeForMove");

            physic.velocity = new Vector2(0, 0);

            physic.AddForce(fr, ForceMode2D.Impulse);

            StartCoroutine("razreshenie");

        }
            
    }


    IEnumerator razreshenie()
    {
        yield return new WaitForSeconds(2f);

        afterKickPlayer = true;

        if (testCor == true)
            testCor = false;
        if (testCor == false)
            testCor = true;


        StartCoroutine("testTimeForMove");
    }
}
