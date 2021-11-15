using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JerkScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D player;

    public static int jerkSum = 1;

    // Update is called once per frame
   public void jerk()
    {
        player.velocity = new Vector3(12, 0, 0);
    }
}
