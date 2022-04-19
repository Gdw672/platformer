using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mimicDamageWave : MonoBehaviour
{
    bool isLeft;
    GameObject player;
    Vector2 startScale;
    void Start()
    {
        player = GameObject.Find("Player");
        startScale = gameObject.transform.localScale;
        if (player.transform.position.x < gameObject.transform.position.x)
        {
            print("left");
        }


       if(player.transform.position.x > gameObject.transform.position.x)
        {
            print("right");
        }
    }
    private void FixedUpdate()
    {
       /* if(gameObject.transform.localScale.x < startScale.x * 30)
        {
            if(gameObject.transform.localScale.x > 0 && isLeft == false)
            {
                gameObject.transform.localScale = new Vector2(transform.localScale.x * -Time.fixedDeltaTime * 52, transform.localScale.y);
                isLeft = true;
            }
            gameObject.transform.localScale = new Vector2(transform.localScale.x * Time.fixedDeltaTime * 52, transform.localScale.y);
        }*/

        if(player.transform.position.x < gameObject.transform.position.x)
        {
            
        }
    }

}
