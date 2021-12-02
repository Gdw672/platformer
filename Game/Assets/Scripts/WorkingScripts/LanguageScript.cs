using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LanguageScript : MonoBehaviour
{
    public static int testLanguage;

    public Sprite exitEng;

    public Sprite efRus;

    public Sprite efEng;

    public Sprite musRus;

    public Sprite musEng;

    public Sprite invisibleRus;

    public Sprite realRus;

    public Sprite invisibleEng;

    public Sprite realEng;

    private Image mus;

    private Image ef;

    private Button eng;

    private Button rus;

    private void Start()
    {

        mus = GameObject.Find("Mus").GetComponent<Image>();

        ef = GameObject.Find("Eff").GetComponent<Image>();

        rus = GameObject.Find("Rus").GetComponent<Button>();

        eng = GameObject.Find("English").GetComponent<Button>();
    }

    public void changeLanguageToEnglish()
    {
        if(testLanguage == 0)
        {
            mus.sprite = musEng;

            ef.sprite = efEng;

            eng.image.sprite = realEng;

            rus.image.sprite = invisibleRus;

            testLanguage = 1;
        }
    }
    public void changeLanguageToRussia()
    {
        if(testLanguage == 1)
        {
            mus.sprite = musRus;

            ef.sprite = efRus;

            rus.image.sprite = realRus;

            eng.image.sprite = invisibleEng;

            testLanguage = 0;
        }

        
    }

    public void goToMEnu()
    {
        SceneManager.LoadScene(0);
    }




}
