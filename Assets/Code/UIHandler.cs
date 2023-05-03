using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    public GameObject[] pauseObjects;

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowInPauseMode");
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(Time.timeScale == 0.0f);
        }
    }

    public GameObject[] GetPauseObjects()
    {
        return pauseObjects;
    }
}
