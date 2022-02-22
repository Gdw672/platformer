using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace playerAndJump {
    public class playerReactionOnAirFlow : MonoBehaviour
    {

        Rigidbody2D player;

        private void Start()
        {
            player = GetComponent<Rigidbody2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "airFlow" && (JerkScript.isJerk == false))
            {
                                player.velocity = new Vector2(0, 5);
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "airFlow" && JerkScript.isJerk == false)
            {
                player.velocity = new Vector2(0, 5);
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {

            if (collision.gameObject.tag == "airFlow")
            {
                player.velocity = new Vector2(0, 0);
            }

        } }
}
