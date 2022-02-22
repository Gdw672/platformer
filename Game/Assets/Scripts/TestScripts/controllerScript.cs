using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace playerAndJump
{
    public class controllerScript : MonoBehaviour
    {
        moveLeft moveLeft = new moveLeft();
        moveRight moveRight = new moveRight();
        Rigidbody2D player;
        
        public void downLeft()
        {

            

            player.velocity = new Vector2(0, player.velocity.y);
            moveLeft.onDown();
          
        }

        public void upLeft()
        {
            
            moveLeft.onUp();
           
        }

        public void downRight()
        {
            player.velocity = new Vector2(0, player.velocity.y);

            moveRight.onDown();

        }

        public void upRight()
        {
            moveRight.onUp();
        }


        private void Start()
        {
            player = GetComponent<Rigidbody2D>();

        }


        private void FixedUpdate()
        {
            

            if (moveLeft.Pressed && gameObject != null)
            {
                gameObject.transform.Translate(-10f * Time.fixedDeltaTime, 0, 0);
            }

            if(moveRight.Pressed && gameObject != null)
            {

                gameObject.transform.Translate(10f * Time.fixedDeltaTime, 0, 0);
            }
        }

       

    }

   


    public class moveLeft : MonoBehaviour
    {
        public static bool isGoRight;

        public GameObject player;

        public static bool Pressed = false;

        public void onDown()
        {
            Pressed = true;
            JerkScript.testRotation = 0;
        }

        private void Start()
        {
            player = GetComponent<GameObject>();
        }

        public void onUp()
        {
            Pressed = false;
        }
    }

    public class moveRight : MonoBehaviour
    {
        public static bool isGoLeft;

        public GameObject player;

        public static bool Pressed = false;

        public void onDown()
        {
            Pressed = true;
            JerkScript.testRotation = 1;
        }

        private void Start()
        {
            player = GetComponent<GameObject>();
        }
        public void onUp()
        {
            Pressed = false;
        }
    }


}