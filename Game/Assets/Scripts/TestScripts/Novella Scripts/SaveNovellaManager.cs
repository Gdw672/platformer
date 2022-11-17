using UnityEngine;
using UnityEngine.UI;
using Fungus;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveNovellaManager : MonoBehaviour
{
    public static SaveNovellaManager saveNovellaManager;
    protected SaveNovellaManager() { }
    public SaveMenu saveMenu;
    public SaveData SD;
    public Text textLog;
    public string LogFromJson;
    public string saveFilePath;


    private void Awake()
    {
      //  deleteSaves();
        saveFilePath = Application.persistentDataPath + "/SaveLog.json";
        DontDestroyOnLoad(gameObject);
        LoadNovella();
        if (SD.isComplete)
        {
            SceneManager.LoadScene("LVL1");
        }
    }

    void deleteSaves()
    {
        File.Delete(Application.persistentDataPath + "/SaveLog.json");
    }
    public void SaveNovella()
    {
        SD = new SaveData();
        SD.NovellaText = textLog.text;
        SD.isComplete = true;

        string str = JsonUtility.ToJson(SD, true);

        File.WriteAllText(saveFilePath, str);      
        
    }
    
    public void LoadNovella()
    {
        SD = JsonUtility.FromJson<SaveData>(File.ReadAllText(saveFilePath));
    }
}


public class SaveData
{
    public string NovellaText;
    public bool isComplete;
}
