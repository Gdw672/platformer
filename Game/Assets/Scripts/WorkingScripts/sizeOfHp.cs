using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace playerAndJump {
    public class sizeOfHp : MonoBehaviour
    {
        float hpForSize;
        Vector2 defoultSize;

        private void Start()
        {

            hpForSize = playerHp.hp;
            defoultSize = gameObject.transform.localScale;

        }
        void Update()
        {
            if (hpForSize != playerHp.hp)
            {
                gameObject.transform.localScale = new Vector2(defoultSize.x * (playerHp.hp / 100), defoultSize.y * (playerHp.hp / 100));

                hpForSize = playerHp.hp;
            }
        }
    }
}