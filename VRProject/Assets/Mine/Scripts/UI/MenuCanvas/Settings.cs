using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
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
}
