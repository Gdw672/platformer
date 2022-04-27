using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mimicDetectPlayer : MonoBehaviour
{
    mimicBehavior mimicBody;
    internal bool handOverDamage;

    private void Start()
    {
        mimicBody = gameObject.transform.parent.GetComponent<mimicBehavior>();
        handOverDamage = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            mimicBody.startAgroAndAttack();
        }
    }
    private void Update()
    {
        if(handOverDamage)
        {
            mimicBody.startAgroAndAttack();
            handOverDamage = false;
        }
    }
}
