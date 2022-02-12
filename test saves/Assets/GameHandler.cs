using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;



public class GameHandler : MonoBehaviour
{
    private void Start()
    {
        /* PlayerData playerData = new PlayerData();
         playerData.position = new Vector3(5, 0);

         playerData.health = 8000;

         string json = JsonUtility.ToJson(playerData);

         Debug.Log(json);

         File.WriteAllText(Application.dataPath + "/saveFile.json", json);*/

        string json = File.ReadAllText(Application.dataPath + "/saveFile.json");

        PlayerData loadedPlayerData = JsonUtility.FromJson<PlayerData>(json);

        Debug.Log("position " + loadedPlayerData.position);
        Debug.Log("health " + loadedPlayerData.health);
    }


    private class PlayerData
    {
        public Vector3 position;

        public int health;
    }
}

