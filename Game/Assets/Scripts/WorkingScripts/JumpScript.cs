using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace playerAndJump
{
    public class JumpScript : MonoBehaviour
    {


        public Rigidbody2D player;


        public static int sumJump = 1;


        public void jump()
        {
            player.velocity = new Vector3(0, 12, 0);

            sumJump = 0;



        }

        public void realJump()
        {


            if (sumJump == 1 && player != null)
            {

                jump();
            }


        }

       


       


        private void Update()
        {



        }

    }
}
 

