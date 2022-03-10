using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace playerAndJump
{

    public class enemyDeadAndActivateEv : MonoBehaviour
    {
        droppPatronsController dropp;


        private void Start()
        {
            dropp = transform.parent.GetComponent<droppPatronsController>();
        }

        private void OnDestroy()
        {
            dropp.isDeadEnemy = true;
        }
    }
    
}