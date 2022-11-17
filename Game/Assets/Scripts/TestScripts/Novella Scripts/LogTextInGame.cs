using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class LogTextInGame : MonoBehaviour
{
    private string saveFilePath;
    private SaveData SD;
    public static LogTextInGame logText;
    protected LogTextInGame() { }



    private void Start()
    {
        saveFilePath = Application.persistentDataPath + "/SaveLog.json";
        SD = JsonUtility.FromJson<SaveData>(File.ReadAllText(saveFilePath));
        GetComponent<Text>().text = SD.NovellaText;
    }
}
