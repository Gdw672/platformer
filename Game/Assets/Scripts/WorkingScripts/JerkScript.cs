using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace playerAndJump
{
    public class JerkScript : MonoBehaviour
    {
        private Rigidbody2D player;
        public static int jerkSum = 1;
        public static int testRotation = 1;
        public static bool isJerk, isReadyTJerk;
        Vector2 stopJerk = new Vector2(0, -3);
        public Button goLeft, goRight, Jump, Jerk, attackButton;
        strongAttack attack = new strongAttack();
        Transform shadowOfPlayer;
        SpriteRenderer sprite;
        BoxCollider2D boxOfShadow;
        private void Start()
        {
            isJerk = false;
            player = GetComponent<Rigidbody2D>();
            shadowOfPlayer = transform.GetChild(1);

            sprite = shadowOfPlayer.GetComponent<SpriteRenderer>();
            boxOfShadow = shadowOfPlayer.GetComponent<BoxCollider2D>();

            sprite.enabled = false;

            boxOfShadow.enabled = false;

            StartCoroutine(regenerateTJerk());
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "enemy")
            {
                collision.gameObject.GetComponent<Rigidbody2D>().mass = 200;


                if (testRotation == 1)
                {
                    isJerk = false;

                    StopCoroutine(stopJerkCor());

                    player.constraints = RigidbodyConstraints2D.FreezeRotation;

                    player.velocity = new Vector2(0, 0);

                    player.AddForce(new Vector2(-180, 0), ForceMode2D.Impulse);

                    onButtons();

                    jerkSum = 1;

                    collision.gameObject.GetComponent<Rigidbody2D>().mass = 20;

                }
            }
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                defoultJerk();
            }

            if (isReadyTJerk == true && isJerk == true)
            {
                gameObject.layer = 3;
            }
            else
            {
                gameObject.layer = 0;
            }
        }
        public void jerk()
        {
            defoultJerk();
        }
        void defoultJerk()
        {
            moveLeft.Pressed = false;

            moveRight.Pressed = false;

            Vector2 jerkPos = new Vector2(30, 0);

            if (isReadyTJerk)
            {
                sprite.enabled = true;
                boxOfShadow.enabled = true;
            }

            if (testRotation == 0)
                jerkPos = -jerkPos;


            if (jerkSum == 1)
            {
                jerkSum = 0;

                StartCoroutine(stopJerkCor());

                isJerk = true;

                offButtons();

                player.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;

                player.velocity = jerkPos;

            }
        }

        private IEnumerator stopJerkCor()
        {
            yield return new WaitForSeconds(0.5f);

            player.constraints = RigidbodyConstraints2D.FreezeRotation;

            player.velocity = stopJerk;

            isJerk = false;

            if (isReadyTJerk == true)
            {
                isReadyTJerk = false;

                sprite.enabled = false;

                boxOfShadow.enabled = false;

                StartCoroutine(regenerateTJerk());

            }
            onButtons();

            yield return new WaitForSeconds(1f);

            jerkSum = 1;
        }
        IEnumerator regenerateTJerk()
        {
            yield return new WaitForSeconds(10f);

            print("ready");

            isReadyTJerk = true;
        }

        protected internal void offButtons()
        {
            attack.offButtons(goLeft, goRight, attackButton, Jump);
        }

        protected internal void onButtons()
        {
            attack.onButtons(goLeft, goRight, attackButton, Jump);
        }
    }
}
