using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleMusic : MonoBehaviour
{
    Toggle toggleMusic;
    public static bool isMusicOn;

    void Start()
    {
        toggleMusic = GetComponent<Toggle>();
        isMusicOn = toggleMusic.isOn;

        toggleMusic.onValueChanged.AddListener(delegate
        {
            ToggleValuesChanged(toggleMusic);
        });
    }

    void ToggleValuesChanged(Toggle change)
    {
        if (toggleMusic.isOn)
        {
            isMusicOn = true;
            GameObject.FindGameObjectsWithTag("Music")[0].GetComponent<AudioSource>().mute = isMusicOn;
        }
        else
        {
            isMusicOn = false;
            GameObject.FindGameObjectsWithTag("Music")[0].GetComponent<AudioSource>().mute = isMusicOn;
        }
    }
}
