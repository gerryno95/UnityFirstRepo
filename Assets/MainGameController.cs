using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class MainGameController : MonoBehaviour
{
    public static MainGameController instance;
    public string playerName = "Player";
    [NonSerialized] public Match bestMatch;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }
    private void Start()
    {
        LoadBestMatch();
        if (bestMatch != null)
        {
            int bestScore = bestMatch.score;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Save(int score)
    {
        int bestScore = 0;
        if (bestMatch != null)
        {
            bestScore = bestMatch.score;
        }
        if (bestScore < score)
        {
            if (bestMatch == null)
            {
                bestMatch = new Match();
            }
            bestMatch.name = playerName;
            bestMatch.score = score;

            string json = JsonUtility.ToJson(bestMatch);
            File.WriteAllText(Application.persistentDataPath + "/bestmatch.json", json);
        }

    }

    public void LoadBestMatch()
    {
        string path = Application.persistentDataPath + "/bestmatch.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Match data = JsonUtility.FromJson<Match>(json);
            bestMatch = data;
        }

    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
