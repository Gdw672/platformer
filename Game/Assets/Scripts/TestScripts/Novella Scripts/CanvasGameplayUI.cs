using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace playerAndJump
{

    public class CanvasGameplayUI : MonoBehaviour
    {
        [SerializeField] private Button Left, Right;
        [SerializeField] private controllerScript controllerScript;
        [SerializeField] private Rigidbody2D player;
        public static CanvasGameplayUI canvasGameplayUI;
        internal Canvas canvas;
        private void Awake()
        {
            canvasGameplayUI = this;
            canvas = canvasGameplayUI.GetComponent<Canvas>();
            GameplayDialogue.sumOfDialog = 0;
        }

        private void Update()
        {
            print(moveRight.Pressed);
        }
        private void OnDisable()
        {
            Left.interactable = false;
            Right.interactable = false;
            moveLeft.Pressed = false;
            moveRight.Pressed = false;
        }
        protected CanvasGameplayUI() { }



    }
}