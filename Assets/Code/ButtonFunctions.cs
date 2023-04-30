using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonFunctions : MonoBehaviour
{
    GameObject[] pauseMode;
    GameObject[] playMode;

    // [SerializeField] InputField playerNameInput;
    // Start is called before the first frame update
    void Start()
    {
        // playerNameInput.text = PersistentData.Instance.GetName();

        Time.timeScale = 1.0f;

        pauseMode = GameObject.FindGameObjectsWithTag("ShowInPauseMode");
        playMode = GameObject.FindGameObjectsWithTag("ShowInPlayMode");

        foreach (GameObject g in pauseMode)
            g.SetActive(false);
    }

    // Update is called once per frame
    void Update() { }

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

        foreach (GameObject g in pauseMode)
            g.SetActive(true);

        foreach (GameObject g in playMode)
            g.SetActive(false);
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;

        foreach (GameObject g in pauseMode)
            g.SetActive(false);

        foreach (GameObject g in playMode)
            g.SetActive(true);
    }

    public void PlayGame()
    {
        GameObject controller = GameObject.FindGameObjectWithTag("GameController");
        if (controller != null)
        {
            controller.GetComponent<PersistentData>().SetScore(0);
        }
        // string playerName = playerNameInput.text;
        //  PersistentData.Instance.SetName(playerName);
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
