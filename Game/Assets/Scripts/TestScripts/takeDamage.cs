using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace playerAndJump
{
    public class takeDamage : MonoBehaviour
    {
        int hp = 100;

        Vector2 vectorLeft = new Vector2(40, 15);

        Vector2 vectorRight = new Vector2(-40, 15);

        private Rigidbody2D enemyBody;

        private void Start()
        {
            enemyBody = gameObject.GetComponent<Rigidbody2D>();
        }

        void Damage()
        {
            hp -= 20;

            if (JerkScript.testRotation == 1)
            {
                enemyBody.AddForce(vectorLeft, ForceMode2D.Impulse);
            }
            if(JerkScript.testRotation == 0)
            {
                enemyBody.AddForce(vectorRight, ForceMode2D.Impulse);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "KickPlayer")
            {
                Damage();

                if (hp <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}