using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace playerAndJump
{

    public class enemyBehaviotLong : MonoBehaviour
    {
        private Rigidbody2D physic;

        public Transform player;

        public float speed;

        public float agroDistance;

        int hp;

        public GameObject bullet;

        public bool barier;

        private bool testVector;

        private bool testCor;
        protected internal bool afterKickPlayer , isShot;

        private Vector2 fr = new Vector2(70, 50);

        private void Start()
        {
            physic = gameObject.GetComponent<Rigidbody2D>();

            barier = true;

            testVector = true;

            testCor = true;

            afterKickPlayer = true;
        }


        private void Update()
        {
            hp = gameObject.GetComponent<takeDamage>().hp;

            if (hp <= 0)
                StopAllCoroutines();

            if (player != null && gameObject != null)
            {
                float destToPlayer = Vector2.Distance(transform.position, player.position);

                if (destToPlayer < agroDistance && afterKickPlayer == true)
                {
                    if (barier == true && afterKickPlayer == true)
                        startHunting();
                    movement();

                }


                
            }
            
        }


        void startHunting()
        {
            print("Start Hunt");

            StartCoroutine(createBullet());
        }

        void movement()
        {
            StartCoroutine("testTimeForMove");
            if (testVector == true && afterKickPlayer == true)
            {
                transform.localScale = new Vector2(0.76f, 0.76f);

                physic.velocity = new Vector2(3, 0);
            }

            if (testVector == false && afterKickPlayer == true)
            {
                transform.localScale = new Vector2(-0.76f, 0.76f);
                physic.velocity = new Vector2(-3, 0);
            }
        }

        IEnumerator testTimeForMove()
        {
            if (testCor == true && afterKickPlayer == true)
            {
                testCor = false;

                yield return new WaitForSeconds(2);

                if (testVector == true)
                    testVector = false;
                else
                    testVector = true;

                testCor = true;

                print(testCor);
            }
        }


        IEnumerator createBullet()
        {
            GameObject clone;

            barier = false;

            System.Random randomTime = new System.Random();

            float rnd = randomTime.Next(2, 4);

            yield return new WaitForSeconds(rnd);

            StartCoroutine(isShoot());

            clone = GameObject.Instantiate(bullet);

            clone.tag = "bullet";

            if (gameObject.transform.position.x < player.position.x)
            {
                clone.transform.position = new Vector2(gameObject.transform.localPosition.x + 1, gameObject.transform.localPosition.y + 3.4f);
            }
            if (gameObject.transform.position.x > player.position.x)
            {
                clone.transform.position = new Vector2(gameObject.transform.localPosition.x - 1, gameObject.transform.localPosition.y + 3.4f);
            }

            barier = true;
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "KickPlayer")
            {
                
                afterKickPlayer = false;

                StopCoroutine("testTimeForMove");

                StopCoroutine(createBullet());

                physic.velocity = new Vector2(0, 0);

                physic.AddForce(fr, ForceMode2D.Impulse);

                StartCoroutine("razreshenie");

            }

        }
        IEnumerator razreshenie()
        {
            yield return new WaitForSeconds(5f);

            afterKickPlayer = true;

            if (testCor == true)
                testCor = false;
            if (testCor == false)
                testCor = true;


            StartCoroutine("testTimeForMove");
        }


        IEnumerator isShoot()
        {
            isShot = true;

            yield return new WaitForSeconds(0.6f);

            isShot = false;
        }
    }
}