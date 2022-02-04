using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace playerAndJump
{
    public class JumpScript : MonoBehaviour
    {


        Rigidbody2D player;

        public static int sumJump;
        public static bool wasJump;
        int maxJump;

        private void Start()
        {
            player = gameObject.GetComponent<Rigidbody2D>();

            maxJump = 2;

            wasJump = false;
        }


        private void Update()
        {
            jumpFromPC();


           
        }

        public void jump()
        {
            if (sumJump > 0)
            {
                  wasJump = true;
    
                  player.velocity = Vector2.zero;

                  player.AddForce(new Vector2(0, 100) * 1.6f, ForceMode2D.Impulse);

                  sumJump -= 1;
            }
        }

        public void realJump()
        {
            if (sumJump > 0 && player != null)
            {
                jump();
            }
        }

       void jumpFromPC()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if (sumJump > 0 && player != null)
                {
                    jump();
                }
            }
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
            if(collision.gameObject.tag == "Ground")
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
    
      
    }
}
 

