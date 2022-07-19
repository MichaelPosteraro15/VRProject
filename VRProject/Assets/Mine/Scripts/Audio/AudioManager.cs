using System;
using UnityEngine;


//audioManager ci permette facilmente di accedere ai suoni inseriti nell'array
//i principali metodi che possiamo usare sono play e stop
public class AudioManager : MonoBehaviour {

	public static AudioManager instance;

	[Range(0f, 1f)]
	public static float volume;

	//array di suoni che possiamo usare quando vogliamo,tramite tale classe
	public Sound[] sounds;

	void Start ()
	{
		if (instance != null)
		{
			Destroy(gameObject);
		} else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}
	}

	//il metodo play va a ricercare il suono nell'array e successivamente fa partire la clipaudio
	public void Play (string sound)
	{
		//trova il suono nell'array e lo riproduce
		Sound s = Array.Find(sounds, item => item.name == sound);
		s.source.Play();
	}

	//il metodo Stop va a ricercare il suono nell'array e successivamente fa stoppare la clipaudio

	public void Stop(string sound)
	{

		Sound s = Array.Find(sounds, item => item.name == sound);
		s.source.Stop();
	}

	//set volume
	public void SetVolume(float v)
    {
		foreach (Sound s in sounds)
        {
			s.setVolume(v);
        }
    }

	public void StopAll()
	{
		foreach (Sound s in sounds)
		{
			s.source.Stop();
		}
	}

	public void PauseAll()
	{
		foreach (Sound s in sounds)
		{
			
			s.source.Pause();
		}
	}

	public void setListnerPause(bool v)
	{
		AudioListener.pause = v;
		
	}



}
