using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mimicDetectPlayer : MonoBehaviour
{
    mimicBehavior mimicBody;
    bool isPlayerInRadius = false;
    internal bool handOverDamage;

    private void Start()
    {
        mimicBody = gameObject.transform.parent.GetComponent<mimicBehavior>();
        handOverDamage = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("mimic attack");
        isPlayerInRadius = true;
        if (collision.gameObject.tag == "Player")
        {
            mimicBody.startAgroAndAttack();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        print("mimic stop attak");
        isPlayerInRadius = false;
    }
    private void Update()
    {
        if(handOverDamage && isPlayerInRadius)
        {
            mimicBody.startAgroAndAttack();
            handOverDamage = false;
        }
    }
}
