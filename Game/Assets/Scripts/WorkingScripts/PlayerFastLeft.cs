using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace playerAndJump
{
    public class PlayerFastLeft : MonoBehaviour
    {
        Vector2 impulseL = new Vector2(-100, 180);
        private Rigidbody2D player;
        Vector2 impulseR = new Vector2(70, 150);

        Vector2 impulseBullet = new Vector2(50, 75);

        Vector2 impulseBulletLeft = new Vector2(-50, 75);

        private void Start()
        {
            player = GetComponent<Rigidbody2D>();
        }
        void impulse(Vector2 vector)
        {
            player.constraints = RigidbodyConstraints2D.FreezeRotation;

            player.velocity = new Vector2(0, 0);

            player.AddForce(vector, ForceMode2D.Impulse);
        }


        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "enemy" && collision.gameObject.transform.position.x < gameObject.transform.position.x)
            {
                impulse(impulseR);
            }

            if (collision.gameObject.tag == "enemy" && collision.gameObject.transform.position.x > gameObject.transform.position.x)
            {
                impulse(impulseL);
            }

            if (collision.gameObject.tag == "bullet" && collision.gameObject.transform.position.x < gameObject.transform.position.x)
            {
                impulse(impulseBullet);

                Destroy(collision.gameObject);

            }

            if (collision.gameObject.tag == "bullet" && collision.gameObject.transform.position.x > gameObject.transform.position.x)
            {
                impulse(impulseBulletLeft);

                Destroy(collision.gameObject);
            }

            if (collision.gameObject.tag == "Suiside" && collision.gameObject.transform.position.x < gameObject.transform.position.x)
            {
                impulse(impulseR);
            }

            if (collision.gameObject.tag == "Suiside" && collision.gameObject.transform.position.x > gameObject.transform.position.x)
            {
                impulse(impulseL);
            }

        }




    }
}
