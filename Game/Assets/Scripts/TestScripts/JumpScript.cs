using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace playerAndJump
{
    public partial class JumpScript : MonoBehaviour
    {

        wallAndPlayerReaction playerAndWall;
        Rigidbody2D player;

        public static int sumJump;
        public static bool wasJump;
        int maxJump;
        Animation animationOfPlayer;

        private void Start()
        {
            playerAndWall = gameObject.GetComponent<wallAndPlayerReaction>();

            player = gameObject.GetComponent<Rigidbody2D>();

            maxJump = 2;

            wasJump = false;

            animationOfPlayer = gameObject.GetComponent<Animation>();
        }


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                realJump();

            }
        }

        public void jump()
        {
           
                  wasJump = true;
    
                  player.velocity = Vector2.zero;

                  player.AddForce(new Vector2(0, 100) * 1.6f, ForceMode2D.Impulse);

                  sumJump -= 1;
            
        }

        public void realJump()
        {
            if (sumJump > 0 && player.gameObject != null && playerAndWall.onWall == false)
            {
                jump();
                print("defualt");
            }

            if(sumJump > 0 && player.gameObject != null && playerAndWall.onWall == true)
            {
                print("jumpFromWall");
                jumpFromWall();
            }
        }

       void jumpFromPC()
        {
            realJump();
        }


        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Ground")
            {
                sumJump = maxJump;

                wasJump = false;
            }
        }


        private void OnCollisionExit2D(Collision2D collision)
        {
            if(collision.gameObject.tag == "Ground" && animationOfPlayer.sumOfGround == 0)
            {
                if(wasJump == false)
                StartCoroutine(startOffJump());
            }
        }

        IEnumerator startOffJump()
        {
            yield return new WaitForSeconds(0.2f);

            if (wasJump == false)
                sumJump -= 1;
        }
        void jumpFromWall()
        {
            if (playerAndWall.wallIsRight)
            {
                player.AddForce(new Vector2(-10, 0), ForceMode2D.Impulse);
            }

            if(playerAndWall.wallIsLeft)
            {
                player.AddForce(new Vector2(10, 0), ForceMode2D.Impulse);
            }

            StartCoroutine(waitForJumpWall());

        }

        IEnumerator waitForJumpWall()
        {

            yield return new WaitForSeconds(0.05f);

            if (playerAndWall.wallIsRight)
            {
                JerkScript.testRotation = 0;

                player.AddForce(new Vector2(-20, 24) * 10f, ForceMode2D.Impulse);

                sumJump -= 1;
            }

           if(playerAndWall.wallIsLeft)
            {
                JerkScript.testRotation = 1;

                player.AddForce(new Vector2(20, 24) * 10f, ForceMode2D.Impulse);

                sumJump -= 1;
            }
        }

        
    }
}
 

