using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LogTextNovella : MonoBehaviour
{
    public static LogTextNovella TextNovella;
    protected LogTextNovella() { }

    private void Start()
    {
        TextNovella = this;
    }


    public string GetText()
    {
        string text =TextNovella.GetComponent<Text>().text;
        return text;
    }
} 
