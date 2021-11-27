using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace playerAndJump
{
    

    public class playerForJump : JumpScript
    {


        JumpScript Jump = new JumpScript();

        private void OnCollisionStay(Collision collision)
        {
            if(collision.gameObject.tag == "Ground")
            {
                sumJump = 1;
            }
        }

        void Start()
        {
           
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            
            if(collision.tag == "Ground")
            {

                sumJump = 1;

            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if(collision.tag == "Ground")
            { 
                sumJump = 0;
            }
        }

        void Update()
        {

        }
        
    }
    
}