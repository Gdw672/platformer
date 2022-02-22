using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace playerAndJump
{
    public class regenerateBullet : MonoBehaviour
    {
        playerCreatePatrons playerPatrons;

        private void Start()
        {
            playerPatrons = GetComponent<playerCreatePatrons>();

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "boxOfPatrons" && playerPatrons.sumOfPatrons < 5)
            {
                regen();

                Destroy(collision.gameObject);
            }
        }
        void regen()
        {
            playerPatrons.sumOfPatrons = 5;
        }

    }
}