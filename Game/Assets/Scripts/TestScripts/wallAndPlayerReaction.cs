using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace playerAndJump
{
    public class wallAndPlayerReaction : MonoBehaviour
    {
       internal bool wallIsLeft, wallIsRight;

       public Button goRight;

        private Rigidbody2D player;

        internal bool onWall;

        private void Start()
        {
            
            onWall = false;
            player = GetComponent<Rigidbody2D>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "wall")
            {
                JumpScript.sumJump = 1;

                onWall = true;

                player.velocity = new Vector2(0, -1.5f);

                detectVoid(collision);
                
            }
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "wall")
            {
                player.velocity = new Vector2(0, -1.5f);
                moveRight.Pressed = false;
                moveLeft.Pressed = false;
            }



        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if(collision.gameObject.tag == "wall")
            {
                onWall = false;

            }
        }

        void detectVoid(Collision2D collision)
        {
            if(collision.gameObject.transform.position.x > gameObject.transform.position.x )
            {
                wallIsRight = true;
                wallIsLeft = false;
            }
            else 
            {
                wallIsLeft = true;
                wallIsRight = false;
            }
           
        }
    }
}