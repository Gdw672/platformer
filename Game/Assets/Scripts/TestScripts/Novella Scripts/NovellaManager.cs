using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NovellaManager : MonoBehaviour
{
    [SerializeField] private Text text;
    private void Start()
    {
        text.text = LogTextNovella.TextNovella.GetText();
    }
}
