using System.Collections;
using System.Collections.Generic;
using System.IO; 
using UnityEngine;

public class SaveHandler : MonoBehaviour
{
    public string playerName; 
    public string highscoreHolder;
    public int highscore;

    public static SaveHandler Instance;

    private void Start()
    {
        LoadGame(); 
    }
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]

    class SaveData
    {
        public string playerName; 
        public string highscoreHolder;
        public int highscore;
    }

    public void SaveGame()
    {
        SaveData data = new SaveData();
        data.playerName = playerName; 
        data.highscoreHolder = highscoreHolder;
        data.highscore = highscore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName; 
            highscoreHolder = data.highscoreHolder;
            highscore = data.highscore;
        }
    }
}
