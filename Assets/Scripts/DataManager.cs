using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public static string nickname;
    public static string score_nickname;
    public static int score;

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

    public void SetNickname(string name)
    {
        nickname = name;
    }

    public string GetNickname()
    {
        return nickname;
    }

    public string GetBestNick()
    {
        return score_nickname;
    }

    public void SetScore(int points, string name)
    {
        if (score <= points)
        {
            score_nickname = name;
            score = points;
        }
    }

    public int GetScore()
    {
        return score;
    }

    [System.Serializable]
    class SaveData
    {
        public string nickname;
        public int score;
    }

    public void SaveAll()
    {
        SaveData data = new SaveData();
        data.nickname = score_nickname;
        data.score = score;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadAll()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            score_nickname = data.nickname;
            score = data.score;
        }
    }
}
