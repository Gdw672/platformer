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

    private void Start()
    {
        physic = gameObject.GetComponent<Rigidbody2D>();

        barier = true;
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
            } else
            {
                stopHunting();
            }  
        }
    }

    
    void startHunting()
    {
        print("Start Hunt");

        StartCoroutine("createBullet");
    }

   void stopHunting()
    {
        physic.velocity = new Vector2(0, 0);
    }

    IEnumerator createBullet()
    {
        barier = false;

        System.Random randomTime = new System.Random();

        float rnd = randomTime.Next(1, 4);

       yield return new WaitForSeconds(rnd);

        Instantiate(bullet);

        bullet.transform.position = gameObject.transform.position;

        barier = true;
    }

    
    

}
