using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace playerAndJump
{
    public class DestroyBullet : MonoBehaviour
    {
       

        private void Awake()
        {
            BulletFly bulletForCor = new BulletFly();
            StartCoroutine(bulletForCor.destroyFromTime(7, gameObject));
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Destroy(gameObject);
        }
    }
}