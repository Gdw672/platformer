using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace playerAndJump
{


    public class attackScript : MonoBehaviour
    {
        public static bool isHit;

        public Button hit;

        public static decimal testHitOf;

        BoxCollider2D box;
        SpriteRenderer render;

        private void Start()
        {
            isHit = false;

            testHitOf = 1;

            box = gameObject.GetComponent<BoxCollider2D>();

            render = gameObject.GetComponent<SpriteRenderer>();


            box.enabled = false;

            render.enabled = false;
        }
        public void ac()
        {
            if(GetComponent<strongAttack>().attackIsReady == false && GetComponent<strongAttack>().attackIsStart == false)
            {
                StartCoroutine("ssa");

            }

        }

        private IEnumerator ssa()
        {
            if(JerkScript.testRotation == 1 )
            gameObject.transform.localPosition = new Vector2(2f, 3.5f);

            if(JerkScript.testRotation == 0)
                gameObject.transform.localPosition = new Vector2(2f, 3.5f);

            hit.enabled = false;

            isHit = true;

            testHitOf++;

            box.enabled = true;

            render.enabled = true;

            yield return new WaitForSeconds(0.3f);

            hit.enabled = true;

            gameObject.transform.localPosition = new Vector2(1.5f, -30f);

            render.enabled = false;

            isHit = false;
        }
    }
}