using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace playerAndJump {
    public class mimicDamageWave : MonoBehaviour
    {
        bool isLeft, isRight, isMinus;
        GameObject player;
        Vector2 startScale;
        mimicDetectPlayer parentComp;
        void Start()
        {
            parentComp = gameObject.transform.parent.GetComponent<mimicDetectPlayer>();
            BulletFly bulletFly = new BulletFly();
            StartCoroutine(bulletFly.destroyFromTime(2.5f, gameObject));
            player = GameObject.Find("Player");
            startScale = gameObject.transform.localScale;
            if (player.transform.position.x < gameObject.transform.position.x)
            {
                isLeft = true;
                isRight = false;
            }


            if (player.transform.position.x > gameObject.transform.position.x)
            {
                isLeft = false;
                isRight = true;

            }
        }
        private void FixedUpdate()
        {
            if (gameObject.transform.localScale.x < startScale.x * 30 && isLeft)
            {

                /* if(gameObject.transform.localScale.x > 0 && isLeft == false)
                 {
                     gameObject.transform.localScale = new Vector2(transform.localScale.x * -Time.fixedDeltaTime * 52, transform.localScale.y);
                     isLeft = true;
                 }*/
                gameObject.transform.localScale = new Vector2(transform.localScale.x * Time.fixedDeltaTime * 52, transform.localScale.y);
            }

            if (-gameObject.transform.localScale.x < startScale.x * 30 && isRight)
            {

                if (gameObject.transform.localScale.x > 0 && isMinus == false)
                {
                    gameObject.transform.localScale = new Vector2(transform.localScale.x * -Time.fixedDeltaTime * 52, transform.localScale.y);
                    isMinus = true;
                }
                gameObject.transform.localScale = new Vector2(transform.localScale.x * Time.fixedDeltaTime * 52, transform.localScale.y);
            }





        }
        private void OnDestroy()
        {
            parentComp.handOverDamage = true;
        }
    }
    
}
