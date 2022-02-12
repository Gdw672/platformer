using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;



public class LanguageScript : MonoBehaviour
{
    public static int testLanguage;

    public Sprite efRus, efEng, musRus, musEng, invisibleRus, realRus, invisibleEng, realEng;

    private Image mus, ef;

    private Button eng, rus;


    private void Start()
    {
        mus = GameObject.Find("Mus").GetComponent<Image>();

        ef = GameObject.Find("Eff").GetComponent<Image>();

        rus = GameObject.Find("Rus").GetComponent<Button>();

        eng = GameObject.Find("English").GetComponent<Button>();

        loadLanguage();


        if (testLanguage == 0)
        {
            changeWithoutCheckRu();
        }
        else
        {
            changeWithoutCheckEng();
        }

    }

   
    public void changeLanguageToEnglish()
    {
        if (testLanguage == 0)
        {
            changeWithoutCheckEng();

        }
    }
    public void changeLanguageToRussia()
    {
        if (testLanguage == 1)
        {
            changeWithoutCheckRu();
        }


    }


    void changeWithoutCheckEng()
    {
        mus.sprite = musEng;

        ef.sprite = efEng;

        eng.image.sprite = realEng;

        rus.image.sprite = invisibleRus;

        testLanguage = 1;
    }
    void changeWithoutCheckRu()
    {
        mus.sprite = musRus;

        ef.sprite = efRus;

        rus.image.sprite = realRus;

        eng.image.sprite = invisibleEng;

        testLanguage = 0;
    }

    public void saveLanguage()
    {
        save save = new save();

        save.saveLanguage = testLanguage;

        string json = JsonUtility.ToJson(save);

        File.WriteAllText(Application.dataPath + "/Scripts/saveLanguage.json", json);
    }

    void loadLanguage()
    {
        save saveS = new save();

        string json = File.ReadAllText(Application.dataPath + "/Scripts/saveLanguage.json");

        saveS = JsonUtility.FromJson<save>(json);

        testLanguage = saveS.saveLanguage;
    }

    public void goToMEnu()
    {

        saveLanguage();

        SceneManager.LoadScene(0);
    }


   private class save
    {

        public int saveLanguage;

    }

    


}
