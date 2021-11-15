using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
public class MoveLeft : MonoBehaviour
{


    public GameObject player;

    bool Pressed = false;
    public void onDown()
    {
        Pressed = true;
    }

    public void onUp()
    {
        Pressed = false;
    }

    

    void Update()
    {
        if (Pressed && player!= null)
        {
            player.transform.Translate(-0.2f, 0, 0);
        }
    }



}
