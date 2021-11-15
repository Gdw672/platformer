using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace enemy { 
public class EnemyBehavior : MonoBehaviour
{
    private Rigidbody2D physic;

    public Transform player;

    public float speed;

    public float agroDistance;



    private void Start()
    {
        physic = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
            if (player != null)
            {

                float destToPlayer = Vector2.Distance(transform.position, player.position);

                if (destToPlayer < agroDistance)
                {
                    startHunting();
                }
                else
                {
                    stopHunting();
                }
            }
    }
   public void startHunting()
    {
        if(player.position.x < transform.position.x)
        {
            physic.velocity = new Vector2(-speed, 0);

           
        }
        else if(player.position.x > transform.position.x)
        {
            physic.velocity = new Vector2(speed, 0);
           

        }
    }



    void stopHunting()
    {
        physic.velocity = new Vector2(0, 0);

    }
}
}