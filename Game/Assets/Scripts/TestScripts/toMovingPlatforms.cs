using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toMovingPlatforms : MonoBehaviour
{
    Rigidbody2D playerBody;

    private void Start()
    {
        playerBody = gameObject.GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "movingPlatform")
        {
            gameObject.transform.parent = collision.transform;
        }
       
            
           
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "movingPlatform")
            gameObject.transform.parent = null;



    }

    private void Update()
    {
        gameObject.transform.localScale = new Vector2(0.25f, 0.25f);
    }
}
