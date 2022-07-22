using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;



//audioManager ci permette facilmente di accedere ai suoni inseriti nell'array
//i principali metodi che possiamo usare sono play e stop
public class AudioManager : MonoBehaviour,IGameManager {
	public ManagerStatus status { get; private set; }

	public static AudioManager instance;
	[SerializeField] private AudioMixerGroup musicMixer;
	[SerializeField] private AudioMixerGroup effectsMixer;

	[Range(0f, 1f)]
	public static float volume;

	//array di suoni che possiamo usare quando vogliamo,tramite tale classe
	public Sound[] sounds;

	public void Startup()
	{
		Debug.Log("Audio manager starting...");
		status = ManagerStatus.Started;

		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
		}
		DontDestroyOnLoad(gameObject);


		//scorriamo tutti i suoni e li inizializziamo
		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;


			//associamo ogni suono ad un mixer in base alla tipologia del suono stesso
			if (s.type == Sound.Type.music)
			{
				//se il suono � di tipologia music allora verr� associato al musicMixer
				s.source.outputAudioMixerGroup = musicMixer;
			}
			else
			{
				//se il suono � di tipologia effect allora verr� associato al effectsMixer
				s.source.outputAudioMixerGroup = effectsMixer;

			}

			//facciamo partire le musiche di sottofondo che saranno diverse in base alla scena in
			//cui ci troviamo
            if (s.playOnAwake)
            {
				if (SceneManager.GetActiveScene().name == "Menu" && s.name== "menuMusic2")
					s.source.Play();
				else if (SceneManager.GetActiveScene().name != "Menu" && s.name == "homeMusic")
						
				{
					s.source.Play();

				}


			}

		}
		Debug.Log("Awake:" + SceneManager.GetActiveScene().name);




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

	//stoppa tutte le musiche
	public void StopAll()
	{
		foreach (Sound s in sounds)
		{
			s.source.Stop();
		}
	}

	//mette in pausa tutte le musiche
	public void PauseAll()
	{
		foreach (Sound s in sounds)
		{
			
			s.source.Pause();
		}
	}

	//mette setta la pausa del listner
	public void setListnerPause(bool v)
	{
		AudioListener.pause = v;
		
	}

   
}
