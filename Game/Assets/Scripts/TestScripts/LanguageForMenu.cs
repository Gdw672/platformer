using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LanguageForMenu : MonoBehaviour
{


    public Sprite playRus;

    public Sprite playEng;

    public Sprite saveRus;

    public Sprite saveEng;

    public Sprite exitRus;

    public Sprite exitEng;

    private Button play;

    private Button save;

    private Button exit;


    void Start()
    {
        play = GameObject.Find("Play").GetComponent<Button>();

        save = GameObject.Find("Save").GetComponent<Button>();

        exit = GameObject.Find("Exit").GetComponent<Button>();

        if (LanguageScript.testLanguage == 1)
        {
            play.image.sprite = playEng;

            save.image.sprite = saveEng;

            exit.image.sprite = exitEng;
        }
        else
        {
            play.image.sprite = playRus;

            save.image.sprite = saveRus;

            exit.image.sprite = exitRus;
        }

    }

    void Update()
    {
    }
}
