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



        gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -2);
        

     
       

    }
}
