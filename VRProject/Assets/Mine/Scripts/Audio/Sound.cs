using UnityEngine;

[System.Serializable]

//classe che ci permette di gestire una clipAudio
public class Sound {
	public enum Type { music,effects};
	public Type type;
	public string name;

	public AudioClip clip;

	[Range(0f, 1f)]
	public float volume;

	[Range(-3f, 3f)]
	public float pitch;

	public bool loop = false;

	[HideInInspector]
	public AudioSource source; //audioSource ci permette di riprodurre l'audioclip

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
