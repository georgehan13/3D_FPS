using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour 
{
	static AudioManager _instance = null;
	public static AudioManager Instance()
	{
		return _instance;
	}

	public AudioClip music = null;

	void Start () 
	{
		if(_instance == null)
			_instance = this;

		if(music !=null)
		{
			audio.clip = music;
			audio.loop = true;
			audio.Play ();
		}
	}

	public void PlaySfx(AudioClip clip)
	{
		audio.PlayOneShot(clip);

	}


}
