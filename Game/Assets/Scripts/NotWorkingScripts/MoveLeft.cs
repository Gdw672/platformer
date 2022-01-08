using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

namespace playerAndJump
{
    public class MoveLeft : MonoBehaviour

    {


        int tesr;
        public GameObject player;

      public static bool isGoLeft = false;


      public static  bool Pressed = false;

        private void Start()
        {
        }

        public void onDown()
        {
            Pressed = true;

            JerkScript.testRotation = 0;
        }

        public void onUp()
        {
            isGoLeft = false;

            Pressed = false;
        }



        private void FixedUpdate()
        {
            if (Pressed && player != null)
            {
                player.transform.Translate(-0.2f, 0, 0);
            }
        }



    }
}