using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace playerAndJump
{
    public class JumpScript : MonoBehaviour
    {


        Rigidbody2D player;

        public static int sumJump;
        public static bool canJump;

        private void Start()
        {
            canJump = true;

            player = gameObject.GetComponent<Rigidbody2D>();

            sumJump = 1;
        }


        private void Update()
        {
            jumpFromPC();
        }

        public void jump()
        {
            player.AddForce(new Vector2(0, 100) * 1.6f, ForceMode2D.Impulse);

            sumJump -= 1;
        }

        public void realJump()
        {
            if (sumJump > 0 && player != null || sumJump > 0 && player != null && Input.GetKeyDown(KeyCode.Space))
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
                sumJump = 1;

                canJump = true;
            }
        }


        private void OnCollisionExit2D(Collision2D collision)
        {
            if(collision.gameObject.tag == "Ground")
            {
                StartCoroutine(startOffJump());

            }
        }

        IEnumerator startOffJump()
        {
            yield return new WaitForSeconds(0.2f);

            sumJump = 0;
        }
    }
}
 

