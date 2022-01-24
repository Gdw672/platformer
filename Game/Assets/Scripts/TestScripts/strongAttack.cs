using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


namespace playerAndJump
{
    public class strongAttack : MonoBehaviour
    {
       public Button attackButton, left, right, jump , jerk;
        BoxCollider2D box;
        SpriteRenderer sprite;
        public int test;


       protected internal bool attackIsReady, attackIsStart;
        

        private void Start()
        {
            
            attackIsStart = false;
            attackIsReady = false;
            
            box = GetComponent<BoxCollider2D>();
            sprite = GetComponent<SpriteRenderer>();
            box.enabled = false;
            sprite.enabled = false;
        }


        public void startTest()
        {
            if(transform.parent.gameObject.GetComponent<Animation>().inAir == false)
                StartCoroutine(prepareToStrongAttack());
            
        }

        public void stopTest()
        {

            StopAllCoroutines();

            StartCoroutine(reload());

        }

        IEnumerator reload()
        {
            if(attackIsReady == true)
            {
               StartCoroutine(doAttack());
            }

            yield return new WaitForSeconds(0.001f);
            attackIsStart = false;
            attackIsReady = false;
        }


        private IEnumerator prepareToStrongAttack()
        {
            yield return new WaitForSeconds(0.3f);

            attackIsStart = true;

            yield return new WaitForSeconds(0.6f);

            attackIsReady = true;
        }



      IEnumerator doAttack()
        {
            print("strong");

            offButtons(left, right, jump, jerk);

            box.enabled = true;

            box.tag = "strongAttack";

            box.transform.localScale = new Vector2(box.transform.localScale.x * 2, box.transform.localScale.y);

            if (JerkScript.testRotation == 1)
                gameObject.transform.localPosition = new Vector2(8f, 14f);

            if (JerkScript.testRotation == 0)
                gameObject.transform.localPosition = new Vector2(8f, 14f);

            attackButton.enabled = false;

            sprite.enabled = true;

            yield return new WaitForSeconds(0.4f);

            box.tag = "KickPlayer";


            onButtons(left, right, jump, jerk);

            attackButton.enabled = true;

            sprite.enabled = false;

            box.transform.localScale = new Vector2(box.transform.localScale.x / 2, box.transform.localScale.y);

            gameObject.transform.localPosition = new Vector2(1.5f, -30f);


        }

       public void offButtons(Button left, Button right, Button jerk , Button jump)
        {
            left.GetComponent<EventTrigger>().enabled = false;
            right.GetComponent<EventTrigger>().enabled = false;
            left.enabled = false;
            right.enabled = false;
            jerk.enabled = false;
            jump.enabled = false;
        }
       public void onButtons(Button left, Button right, Button jerk, Button jump)
        {
            left.GetComponent<EventTrigger>().enabled = true;
            right.GetComponent<EventTrigger>().enabled = true;
            left.enabled = true;
            right.enabled = true;
            jerk.enabled = true;
            jump.enabled = true;
        }


       
            
        

    }
}
