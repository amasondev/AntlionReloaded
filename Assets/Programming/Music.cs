using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour
{
	private AudioClip music;

	// Use this for initialization
	void Start()
	{
		music = audio.clip;
		foreach (AudioSource a in FindObjectsOfType<AudioSource>())
		{			
			if (a != audio && a.clip == music)
			{
				audio.Stop();
				Destroy(gameObject);
			}
		}
	}
}
