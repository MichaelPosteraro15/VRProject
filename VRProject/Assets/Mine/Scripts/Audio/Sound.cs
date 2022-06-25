﻿using UnityEngine;

[System.Serializable]

//classe che ci permette di gestire una clipAudio
public class Sound {

	public string name;

	public AudioClip clip;

	[Range(0f, 1f)]
	public float volume;

	[Range(-3f, 3f)]
	public float pitch;

	public bool loop = false;

	[HideInInspector]
	public AudioSource source;

	public void setVolume(float volume)
    {
		if (volume < 0f)
        {
			volume = 0f;
		}
			
		else if (volume>1f)
        {
			volume = 1f;
        }
    }

}
