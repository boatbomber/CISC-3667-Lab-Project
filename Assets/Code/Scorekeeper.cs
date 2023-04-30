using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scorekeeper : MonoBehaviour
{
    public int score = 0;
    public int level = 0;
    public int scoreThreshold;
    const int DEFAULT_POINTS = 1;

    int GetThreshold(int lvl)
    {
        return (int)(Mathf.Pow(lvl, 2) * 3 + 5);
    }

    void GetSceneInfo()
    {
        level = SceneManager.GetActiveScene().buildIndex + 1;
        scoreThreshold = GetThreshold(level);
        DisplayScene();
    }

    void GetScoreInfo()
    {
        score = PersistentData.Instance.GetScore();
        DisplayScore();
    }

    // Start is called before the first frame update
    void Start()
    {
        GetScoreInfo();
        GetSceneInfo();
    }

    // Update is called once per frame
    void Update()
    {
        GetScoreInfo();
        GetSceneInfo();
        if (score >= scoreThreshold)
        {
            AdvanceScene();
        }
    }

    public void AddPoints()
    {
        AddPoints(DEFAULT_POINTS);
    }

    public void AddPoints(int points)
    {
        score += points;
        PersistentData.Instance.SetScore(score);
    }

    public void DisplayScore()
    {
        TextMeshProUGUI scoreTxt = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        scoreTxt.SetText("Score: " + score);
    }

    public void DisplayScene()
    {
        TextMeshProUGUI sceneTxt = GameObject.Find("SceneText").GetComponent<TextMeshProUGUI>();
        sceneTxt.SetText(SceneManager.GetActiveScene().name);
    }

    public void AdvanceScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ResetGame()
    {
        Debug.Log("Resetting game");
        PersistentData.Instance.SetScore(0);
        SceneManager.LoadScene(0);
    }
}
