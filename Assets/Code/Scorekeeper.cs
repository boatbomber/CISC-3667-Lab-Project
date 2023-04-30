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
        return (int)(Mathf.Pow(lvl - 1, 2) * 3 + 5);
    }

    void GetSceneInfo()
    {
        level = SceneManager.GetActiveScene().buildIndex;
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
        GameObject textObj = GameObject.Find("ScoreText");
        if (textObj == null)
            return;

        textObj.GetComponent<TextMeshProUGUI>().SetText("Score: " + score);
    }

    public void DisplayScene()
    {
        GameObject textObj = GameObject.Find("SceneText");
        if (textObj == null)
            return;

        textObj.GetComponent<TextMeshProUGUI>().SetText(SceneManager.GetActiveScene().name);
    }

    public void AdvanceScene()
    {
        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            Debug.Log("No more scenes to advance to");
            return;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ResetGame()
    {
        Debug.Log("Resetting game");
        PersistentData.Instance.SetScore(0);
        SceneManager.LoadScene(0);
    }
}
