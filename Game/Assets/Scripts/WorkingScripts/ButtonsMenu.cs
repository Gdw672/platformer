using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsMenu : MonoBehaviour
{
    
   public void ExitGame()
    {
        Application.Quit();
    }

   public void StartGame()
    {
        SceneManager.LoadScene("NovellaScene");
    }

    

   public void goToSettings()
    {
        SceneManager.LoadScene("SETTING");


    }
    void Update()
    {
        
    }
}
