using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace playerAndJump
{
    public class scorePatrons : MonoBehaviour
    {
       [SerializeField] private GameObject player;
        playerCreatePatrons playerPatr;
        TMP_Text sumPatr;

        private void Start()
        {
            playerPatr = player.GetComponent<playerCreatePatrons>();
            sumPatr = GetComponent<TMP_Text>();

        }


        private void Update()
        {
            sumPatr.text = playerPatr.sumOfPatrons.ToString();
        }


    }
}