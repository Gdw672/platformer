using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace playerAndJump
{

    public class playerHp : MonoBehaviour
    {
        static public float hp = 100;
        static public bool isTakeDamage;

        private void Update()
        {

            if (hp <= 0)
            {
                SceneManager.LoadScene(0);

                hp = 100;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "bullet")
            {
                hp -= 20;

                StartCoroutine(takeDamage());
            }
            if (collision.gameObject.tag == "enemy")
            {
               hp -= 30;
                StartCoroutine(takeDamage());
            }

            if(collision.gameObject.tag == "Suiside")
            {
                hp -= 50;
                StartCoroutine(takeDamage());
            }
        }

        private void Start()
        {
            isTakeDamage = false;
        }

        IEnumerator takeDamage()
        {
            isTakeDamage = true;

            yield return new WaitForSeconds(0.7f);

            isTakeDamage = false;
        }


    }
}