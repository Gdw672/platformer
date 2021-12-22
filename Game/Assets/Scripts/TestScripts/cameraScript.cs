using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
   public GameObject player;

    Vector3 playerPos;
    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;



        gameObject.transform.position = new Vector3(playerPos.x, gameObject.transform.position.y, gameObject.transform.position.z) ;
        

     
       

    }
}
