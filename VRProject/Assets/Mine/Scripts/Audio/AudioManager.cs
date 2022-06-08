using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public static AudioManager instance;

	//array di suoni che possiamo usare quando vogliamo tramite tale classe
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

	//quando chiamiamo play si ascolta il soud che gli passiamo(che deve essere nell'array)
	public void Play (string sound)
	{
		//trova il suono nell'array e lo riproduce
		Sound s = Array.Find(sounds, item => item.name == sound);
		s.source.Play();
	}

	public void Stop(string sound)
	{

		Sound s = Array.Find(sounds, item => item.name == sound);
		s.source.Stop();
	}

}
