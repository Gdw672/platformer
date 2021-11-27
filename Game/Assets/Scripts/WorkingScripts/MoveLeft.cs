using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

namespace playerAndJump
{
    public class MoveLeft : MonoBehaviour

    {

        public GameObject player;

        bool Pressed = false;
        public void onDown()
        {
            Pressed = true;

            JerkScript.testRotation = 0;
        }

        public void onUp()
        {
            Pressed = false;
        }



        void Update()
        {
            if (Pressed && player != null)
            {
                player.transform.Translate(-0.2f, 0, 0);
            }
        }



    }
}