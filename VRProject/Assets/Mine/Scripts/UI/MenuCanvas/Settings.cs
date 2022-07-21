using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{

    public AudioMixerGroup musicMixer;
    public void SetScreen(int fullScreen)
    {
        if (fullScreen == 1)
        {
            Screen.fullScreen = true;
            Debug.Log("fullScreen");
        }
        else
        {
            Screen.fullScreen = false;
            Debug.Log("minimize");

        }

    }

    public void SetQuality(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
        Debug.Log(quality);

    }

    public void setVolume(float value)
    {
        musicMixer.audioMixer.SetFloat("Music volume",value);
    }
}
