using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFastLeft : MonoBehaviour
{
    Vector2 impulseL = new Vector2(-70, 150);

    Vector2 impulseR = new Vector2(70, 150);
    void impulseLeft()
    {
        GetComponent<Rigidbody2D>().AddForce(impulseL, ForceMode2D.Impulse);
    }

    void impulseRight()
    {
        GetComponent<Rigidbody2D>().AddForce(impulseR, ForceMode2D.Impulse);
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
