using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGameplayUI : MonoBehaviour
{
    public static CanvasGameplayUI canvasGameplayUI;
    internal Canvas canvas;
    private void Awake()
    {
        canvasGameplayUI = this;
        canvas = canvasGameplayUI.GetComponent<Canvas>();
    }

    protected CanvasGameplayUI() {}

 

}
