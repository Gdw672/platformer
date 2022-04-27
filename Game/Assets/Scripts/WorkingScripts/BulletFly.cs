using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace playerAndJump
{
    public class BulletFly : patronsAbstract
    {
        private GameObject player;

        private Rigidbody2D bullet;

        bool testPositionPlayer = true;

        float sidePlayer;

        void Start()
        {
            player = GameObject.Find("Player");

            bullet = gameObject.GetComponent<Rigidbody2D>();

            StartCoroutine(destroyFromTime(3 , gameObject));
        }

        private void Update()
        {
            if (testPositionPlayer == true)
            {
                test();
            }

            if (bullet != null)
            {
                bulletFly();
            }

        }

       public override void bulletFly()
        {
            if (sidePlayer > 0)
            {
                bullet.velocity = new Vector2(15, 0);
            }
            else
            {
                bullet.velocity = new Vector2(-15, 0);
            }
        }

        void test()
        {
            testPositionPlayer = false;

            sidePlayer = player.transform.position.x - transform.position.x;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "KickPlayer" || collision.gameObject.tag == "strongAttack")
            {
                Destroy(gameObject);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Destroy(gameObject);
        }


      internal IEnumerator destroyFromTime(float second , GameObject gameObject)
        {
            yield return new WaitForSeconds(second);

            Destroy(gameObject);

        }
    }
}