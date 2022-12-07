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
        int sumOfDamageFire;
        bool wasDamage;
        

        private void Update()
        {
            if(hp <= 0)
            {
                SceneManager.LoadScene(0);

                hp = 100;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
           

            if (collision.gameObject.tag == "bullet")
            {

                Damage(20);
            
            }
            if (collision.gameObject.tag == "enemy" && collision.gameObject.GetComponent<EnemyBehavior>() == false)
            {
                Damage(30);
            }

            if(collision.gameObject.tag == "enemy" &&collision.gameObject.GetComponent<EnemyBehavior>() == true)
            {
                Damage(50);
            }
            if( collision.gameObject.tag == "bulletFire")
            {
                if(wasDamage == true) {
                    Damage(10);

                }else
                {
                    InvokeRepeating("damageFire", 0, 4);
                }
                Destroy(collision.gameObject);
                
            }

            if (collision.gameObject.tag == "flyDamage")
            {
                Damage(15);
            }


        }


        void damageFire()
        {
            wasDamage = true;
            hp -= 10;
            sumOfDamageFire += 1;
            print(sumOfDamageFire);
            print(hp);
            if(sumOfDamageFire == 3)
            {
                CancelInvoke("damageFire");
                wasDamage = false;
            }
        }
      

        private void Start()
        {
            wasDamage = false;
            sumOfDamageFire = 0;
            isTakeDamage = false;
        }

        void Damage(int damage)
        {
            hp -= damage;
            StartCoroutine(takeDamage());

        }

        IEnumerator takeDamage()
        {
            isTakeDamage = true;

            yield return new WaitForSeconds(0.7f);

            isTakeDamage = false;
        }


    }
}