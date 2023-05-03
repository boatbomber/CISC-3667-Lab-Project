using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsHandler : MonoBehaviour
{
    [SerializeField]
    Slider volumeSlider;

    [SerializeField]
    TMP_Dropdown difficultyDropdown;

    private GameObject controller;

    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
        volumeSlider.value = AudioListener.volume;
        difficultyDropdown.value = controller.GetComponent<PersistentData>().GetDifficulty();
    }

    public void SetDiffuculty()
    {
        controller.GetComponent<PersistentData>().SetDifficulty(difficultyDropdown.value);
    }

    public void SetVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }
}
