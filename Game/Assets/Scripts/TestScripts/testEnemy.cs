using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace playerAndJump
{
    public class testEnemy : NewEnemyBehaviorLong
    {
       

        public override void movement()
        {
            if (toRotation == false)
            {
                toRotation = true;
                enemyPosition = gameObject.transform.position;
            }

            if (enemyPosition.x - gameObject.transform.position.x < -20 || enemyPosition.x - gameObject.transform.position.x > 20)
            {
                leftRight = !leftRight;
                toRotation = false;
            }
        }

    }
}