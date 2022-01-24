using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace playerAndJump
{
    public class Test : EnemyBehavior
    {
        public override void startHunting()
        {
            print("start");
        }

        public override void stopHunting()
        {
            print("stop");
        }

    }
}