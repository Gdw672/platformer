using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mimicDetectPlayer : MonoBehaviour
{
    mimicBehavior mimicBody;

    private void Start()
    {
        mimicBody = gameObject.transform.parent.GetComponent<mimicBehavior>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            mimicBody.startAgroAndAttack();
        }
    }
}
