using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagePuzzleObjects : MonoBehaviour
{

    doorScript parentDoor;
    private void Start()
    {
        parentDoor = gameObject.transform.parent.GetComponent<doorScript>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "KickPlayer" || collision.tag == "strongAttack")
        {
            Destroy(gameObject);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "bulletPlayer")
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if(parentDoor.corIsNow == false)
        {
            parentDoor.isStartCor = true;

        }
    }
}
