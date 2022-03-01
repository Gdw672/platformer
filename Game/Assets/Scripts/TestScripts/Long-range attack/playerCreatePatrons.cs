using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace playerAndJump
{

    public class playerCreatePatrons : MonoBehaviour
    {
        
        internal int sumOfPatrons;

       internal bool isReadyPatron;

        public GameObject bullet;


        private void Start()
        {
            sumOfPatrons = 5;
            isReadyPatron = true;


        }


        public  void createBullet()
        {

            if (sumOfPatrons > 0 && isReadyPatron)
            {
                isReadyPatron = false;
              var clone = Instantiate(bullet);

                clone.tag = "bulletPlayer";
               

                Rigidbody2D cloneBody = clone.GetComponent<Rigidbody2D>();

                Physics2D.IgnoreCollision(clone.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());

                sumOfPatrons -= 1;

                if(gameObject.transform.localScale.x > 0)
                {

                    clone.transform.position = new Vector2(gameObject.transform.localPosition.x + 1.7f, gameObject.transform.position.y + 3.25f);

                    cloneBody.velocity = new Vector2(16, 0); 

                }
                else
                {
                    clone.transform.position = new Vector2(gameObject.transform.localPosition.x - 1.7f, gameObject.transform.position.y + 3.25f);

                    cloneBody.velocity = new Vector2(-16, 0);

                }
                StartCoroutine(reloadPatrons());
            }




        }

        
        private IEnumerator reloadPatrons()
        {
            yield return new WaitForSeconds(0.5f);

            isReadyPatron = true;
        }
        
        
       
    }
}