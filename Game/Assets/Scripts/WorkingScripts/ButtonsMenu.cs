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
        SceneManager.LoadScene(1);
    }

    

   public void goToSettings()
    {
        SceneManager.LoadScene(2);


    }
    void Update()
    {
        
    }
}
