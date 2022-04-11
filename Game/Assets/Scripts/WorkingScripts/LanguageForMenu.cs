using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LanguageForMenu : MonoBehaviour
{


    TMP_Text play, save, exit;

    void Start()
    {
        play = GameObject.Find("Play").transform.GetChild(0).gameObject.GetComponent<TMP_Text>();

        save = GameObject.Find("Save").transform.GetChild(0).gameObject.GetComponent<TMP_Text>();

        exit = GameObject.Find("Exit").transform.GetChild(0).gameObject.GetComponent<TMP_Text>();
     
        LanguageScript langeageSetting = new LanguageScript();

        langeageSetting.loadLanguage();



        if (LanguageScript.testLanguage == 1)
        {
            play.text = "PLAY";

            save.text = "SAVE";

            exit.text = "EXIT";


            
        }
        else
        {
            play.text = "»√–¿“‹";

            save.text = "—Œ’–";

            exit.text = "¬€’Œƒ";
        }

    }
}
