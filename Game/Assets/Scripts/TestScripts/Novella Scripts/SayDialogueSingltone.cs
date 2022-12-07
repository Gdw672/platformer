using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class SayDialogueSingltone : MonoBehaviour
{
    public static SayDialogueSingltone sayDialogueSingltone;
    protected SayDialogueSingltone() {}
    internal DialogInput dialogInput;
    internal Canvas canvasSay;

    private void Awake()
    {
        dialogInput = GetComponent<DialogInput>();
        canvasSay = GetComponent<Canvas>();
        sayDialogueSingltone = this;
    }

   public void SayMenuOn()
    {
        dialogInput.enabled = true;
        canvasSay.enabled = true;
    }

    public void SayMenuOff()
    {
        dialogInput.enabled = false;
        canvasSay.enabled = false;
    }
}
