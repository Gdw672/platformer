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
        public static bool isJerk;
        Vector2 stopJerk = new Vector2(0, -3);
        public Button goLeft;
        public Button goRight;
        public Button Jump;


        private void Start()
        {
            isJerk = false;
            player = GetComponent<Rigidbody2D>();
        }
       

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "enemy")
            {
                if (testRotation == 1)
                {
                    StopAllCoroutines();

                    player.constraints = RigidbodyConstraints2D.FreezeRotation;

                    player.velocity = new Vector2(0, 0);

                    player.AddForce(new Vector2(-90, 150), ForceMode2D.Impulse);

                    onButtons();
                }
                else
                {
                    StopAllCoroutines();

                    player.constraints = RigidbodyConstraints2D.FreezeRotation;

                    player.velocity = new Vector2(0, 0);

                    player.AddForce(new Vector2(90, 150), ForceMode2D.Impulse);

                    onButtons();
                }
            }
        }

       
        public void jerk()
        {

            Vector2 jerkPos = new Vector2(30, 0);

            if (testRotation == 0)
                jerkPos = -jerkPos;


            if (jerkSum == 1)
            {
                jerkSum = 0;

                StartCoroutine(stopJerkCor());

                offButtons();

                player.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;

                player.velocity = jerkPos;

                isJerk = true;
            }

        }

     

        private IEnumerator stopJerkCor()
        {
            yield return new WaitForSeconds(0.5f);

           

            player.constraints = RigidbodyConstraints2D.FreezeRotation;

            player.velocity = stopJerk;

            isJerk = false;

            onButtons();

            yield return new WaitForSeconds(1f);

            jerkSum = 1;

            print("go down");
        }


        
        void offButtons()
        {
            goLeft.GetComponent<MoveLeft>().enabled = false;

            goRight.GetComponent<MoveRight>().enabled = false;

            Jump.GetComponent<Button>().enabled = false;
        }

        void onButtons()
        {
            goLeft.GetComponent<MoveLeft>().enabled = true;

            goRight.GetComponent<MoveRight>().enabled = true;

            Jump.GetComponent<Button>().enabled = true;
        }

        
    }
}