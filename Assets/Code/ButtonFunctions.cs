using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonFunctions : MonoBehaviour
{
    public void TogglePause()
    {
        if (Time.timeScale == 0.0f)
            Resume();
        else
            Pause();
    }

    public void Pause()
    {
        Time.timeScale = 0.0f;

        GameObject controller = GameObject.FindGameObjectWithTag("GameController");
        if (controller != null)
        {
            foreach (GameObject g in controller.GetComponent<UIHandler>().GetPauseObjects())
                g.SetActive(true);
        }
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;

        GameObject controller = GameObject.FindGameObjectWithTag("GameController");
        if (controller != null)
        {
            foreach (GameObject g in controller.GetComponent<UIHandler>().GetPauseObjects())
                g.SetActive(false);
        }
    }

    public void PlayGame()
    {
        GameObject controller = GameObject.FindGameObjectWithTag("GameController");
        if (controller != null)
        {
            controller.GetComponent<PersistentData>().SetScore(0);
        }
        SceneManager.LoadScene("Hills");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LoadHelp()
    {
        SceneManager.LoadScene("Help");
    }
}
