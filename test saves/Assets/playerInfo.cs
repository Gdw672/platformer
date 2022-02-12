using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInfo : MonoBehaviour
{
  protected internal int sum;

    public void plusSum()
    {


        sum++;
        print(sum);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            plusSum();

        }
    }

    
}
