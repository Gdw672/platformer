using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class playerHp : MonoBehaviour
{

    static public int hp = 100;

    private void Update()
    {

        if(playerHp.hp <= 0)
        {
           

            SceneManager.LoadScene(0);

            hp = 100;

        }

    }

}
