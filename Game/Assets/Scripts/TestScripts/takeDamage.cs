using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace playerAndJump

{
    public class takeDamage : MonoBehaviour
    {
        protected internal bool isDeath;

       public int hp = 100;

        Vector2 vectorLeft = new Vector2(20, 0);

        Vector2 vectorRight = new Vector2(-20, 0);

        private Rigidbody2D enemyBody;

        private void Start()
        {
            enemyBody = gameObject.GetComponent<Rigidbody2D>();
        }

        void Damage(int damage)
        {
           

            hp -= damage;

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
                Damage(30);        
            }
            if (collision.gameObject.tag == "strongAttack")
            {
                Damage(50);
            }
            if(collision.gameObject.tag == "shadowOfPlayer")
            {
                Damage(25);
            }
           

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "bulletPlayer")
            {
                Damage(35);
                Destroy(collision.gameObject);
            }
        }

        private void Update()
        {
            if(hp <=  0)
            {
                enemyBody.isKinematic = true;
                isDeath = true;
            }
        }

    }
}