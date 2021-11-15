using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System;
using UnityEngine.SceneManagement;


namespace enemy
{
   


    public class EnemyDamagePlayerHp : MonoBehaviour
    {
        public GameObject player;

        public int power = 25;


        

        public void takeDamage()
        {
            playerHp.hp -= power;

            print(playerHp.hp);


           

        }


        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                InvokeRepeating("takeDamage", 0f, 1f);
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            
            CancelInvoke();
        }

        private void Update()
        {

            

            



        }

    }
}