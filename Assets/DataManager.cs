using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string PlayerName;

    public int HighScore;
    private void Awake() {
        if ( Instance != null )
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        Load();
    }

    [System.Serializable]
    class SaveData {
        public string Playername;
        public int Highscore;
    }

    public void Save() {
        SaveData data = new SaveData();
        data.Playername = PlayerName;
        data.Highscore = HighScore;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }


    public void Load() {
        string path = Application.persistentDataPath + "/savefile.json";
        if ( File.Exists(path) )
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            PlayerName = data.Playername;
            HighScore = data.Highscore;
        }
        
    }


}
