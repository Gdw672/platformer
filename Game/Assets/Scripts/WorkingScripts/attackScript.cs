using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace playerAndJump
{


    public class attackScript : MonoBehaviour
    {
        BoxCollider2D box;
        SpriteRenderer render;

        private void Start()
        {
            box = gameObject.GetComponent<BoxCollider2D>();

            render = gameObject.GetComponent<SpriteRenderer>();


            box.enabled = false;

            render.enabled = false;
        }
        public void ac()
        {
            StartCoroutine("ssa");
        }

        private IEnumerator ssa()
        {
            if(JerkScript.testRotation == 1 )
            gameObject.transform.localPosition = new Vector2(1.5f, 0.1f);

            if(JerkScript.testRotation == 0)
                gameObject.transform.localPosition = new Vector2(-1.5f, 0.1f);

            box.enabled = true;

            render.enabled = true;

            yield return new WaitForSeconds(0.3f);

            gameObject.transform.localPosition = new Vector2(1.5f, -30f);

            render.enabled = false;
        }
    }
}