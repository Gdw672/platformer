using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

namespace playerAndJump {

    [SelectionBase]

    public class droppPatronsController : MonoBehaviour
    {
        public GameObject bullets;
       

        internal bool isDeadEnemy;

        private SkeletonAnimation enemyGo;
        private Vector3 enemtPos;


        private void Start()
        {
            enemyGo = transform.GetChild(0).GetComponent<SkeletonAnimation>();
        }
        private void Update()
        {
           
            if(enemyGo != null)
            {
                enemtPos = enemyGo.transform.position;
            }
                if (isDeadEnemy)
                {
                    System.Random rnd = new System.Random();

                    if (rnd.Next(6) == 0)
                    {

                    spawnPatrons(bullets, enemtPos);

                    BulletFly destroyGo = new BulletFly();

                  StartCoroutine(destroyGo.destroyFromTime(1, gameObject));

                    
                    }

                isDeadEnemy = false;
                }
            
        }
        

        void spawnPatrons(GameObject prefabSpawn , Vector3 spawnCoord)
        {
           var clone = Instantiate(prefabSpawn);

            clone.transform.GetChild(0).transform.position = new Vector3(spawnCoord.x, spawnCoord.y + 2) ;
            clone.transform.GetChild(0).transform.GetChild(0).transform.position = new Vector3(spawnCoord.x, spawnCoord.y + 2);
        }



    }
}
