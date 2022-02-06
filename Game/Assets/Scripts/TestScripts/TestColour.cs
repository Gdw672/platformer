using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class TestColour : MonoBehaviour
{

    Color color;
    void Start()
    {
        color = Color.white;
        color.b = 1f;
        color.g = 1f;
        color.r = 1f;
        var mySkeletonAnimation = GetComponent<SkeletonAnimation>();
        mySkeletonAnimation.skeleton.SetColor(color);
        

        
    }
    

    void Update()
    {
        
    }
}
