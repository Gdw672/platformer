using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace playerAndJump
{
    public class NewEnemyBehaviorLong : MonoBehaviour
    {
        
        public GameObject player, bullet;
        private Rigidbody2D enemyBody;
        private Vector2 enemyPosition;
        public float hp, speed, agroDist;
        private float dist;
        private bool toRotation;
        protected internal bool leftRight, forBullet, isKick, shot;
        Vector2 size;
        private void Start()
        {
             size = new Vector2(gameObject.transform.localScale.x, gameObject.transform.localScale.y);
            forBullet = true;
            toRotation = false;
            enemyBody = gameObject.GetComponent<Rigidbody2D>();
            print("F");
            enemyBody.velocity = new Vector2(3, 0);
            leftRight = false;
        }


        private void Update()
        {
            dist = Vector2.Distance(transform.position, player.transform.position);

            if (player != null && gameObject != null)
            {
               
                movement();

                if (leftRight == false && isKick == false)
                {
                    transform.Translate(Vector2.left * speed * Time.deltaTime, 0);
                    transform.localScale = new Vector2(-size.x, size.y) ;
                }
                if (leftRight == true && isKick == false)
                {
                    transform.Translate(Vector2.right * speed * Time.deltaTime, 0);
                    transform.localScale = size;

                }

                if (dist < agroDist && forBullet == true)
                {
                    StartCoroutine(createBullet());
                }
            }
        }
        void movement()
        {
            if(toRotation == false)
            {
                toRotation = true;
                enemyPosition = gameObject.transform.position;
            }

            if(enemyPosition.x - gameObject.transform.position.x < -5 || enemyPosition.x - gameObject.transform.position.x > 5)
            {
                           
                leftRight = !leftRight;
                toRotation = false;
            }
        }

        IEnumerator createBullet()
        {

            GameObject clone;

            forBullet = false;

            System.Random randomTime = new System.Random();

            float rnd = randomTime.Next(2, 4);
            
            yield return new WaitForSeconds(rnd);

            StartCoroutine(isShot());

            clone = GameObject.Instantiate(bullet);

            clone.tag = "bullet";

            if (gameObject.transform.position.x < player.transform.position.x)
            {
                clone.transform.position = new Vector2(gameObject.transform.localPosition.x + 1, gameObject.transform.localPosition.y + 3.4f);
            }
            if (gameObject.transform.position.x > player.transform.position.x)
            {
                clone.transform.position = new Vector2(gameObject.transform.localPosition.x - 1, gameObject.transform.localPosition.y + 3.4f);
            }

            yield return new WaitForSeconds(0.3f);

            forBullet = true;


        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "KickPlayer" || collision.tag == "strongAttack")
            {
                isKick = true;
                StopAllCoroutines();
                if (forBullet == false)
                    StartCoroutine(regenerationBullet());
            }
        }

        IEnumerator regenerationBullet()
        {
            yield return new WaitForSeconds(3f);
            isKick = false;
            forBullet = true;
        }

        IEnumerator isShot()
        {
            shot = true;

            yield return new WaitForSeconds(0.6f);

            shot = false;

        }
    }
}