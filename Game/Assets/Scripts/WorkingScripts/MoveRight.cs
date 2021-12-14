using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace playerAndJump
{

    public class MoveRight : MonoBehaviour
    {
        public static bool isGoRight;

        public GameObject player;

     public  static bool Pressed = false;
        public void onDown()
        {
            Pressed = true;

            JerkScript.testRotation = 1;
        }

        public void onUp()
        {

            Pressed = false;
        }



        void Update()
        {
            if (Pressed && player != null)
            {
                player.transform.Translate(0.2f, 0, 0);
            }

        }
    }
}