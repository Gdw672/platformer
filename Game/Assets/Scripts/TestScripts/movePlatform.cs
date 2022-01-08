using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[SelectionBase]
public class movePlatform : MonoBehaviour
{

    bool moveRight;
    float speed = 3f;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            coll.transform.parent = transform;
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            coll.transform.parent = null;
        }

    }
    private void Update()
    {
        if(moveRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }

    private void Start()
    {
        moveRight = false;

        StartCoroutine(changeSide());
    }


    IEnumerator changeSide()
    {
        yield return new WaitForSeconds(2f);

        if(moveRight == true)
        {
            moveRight = false;
        }
        else
        {
            moveRight = true;
        }

        StartCoroutine(changeSide());
        
    }

    

}
