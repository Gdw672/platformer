using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace playerAndJump
{


    public class GameplayDialogue : MonoBehaviour
    {
        [SerializeField] private Canvas canvas;
        bool isSceneWasLoaded = false;
        public static int sumOfDialog = 0;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player" && !isSceneWasLoaded)
            {
                if (sumOfDialog == 0)
                    SceneManager.LoadScene("GameplayDialogue", LoadSceneMode.Additive);
                else
                {
                    isSceneWasLoaded = true;
                    DeaactivateCanvas();
                }
                sumOfDialog++;
                canvas.enabled = false;
                GetComponent<BoxCollider2D>().enabled = false;

            }
        }
        public void ActivateCanvas()
        {
            SayDialogueSingltone.sayDialogueSingltone.SayMenuOff();
            CanvasGameplayUI.canvasGameplayUI.canvas.enabled = true;

        }

        public void DeaactivateCanvas()
        {
            SayDialogueSingltone.sayDialogueSingltone.SayMenuOn();
        }

        public void loadScene()
        {
            SceneManager.LoadScene("NovellaScene2");
        }
    }

}