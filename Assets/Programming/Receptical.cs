using UnityEngine;
using System.Collections;

public class Receptical : MonoBehaviour
{
	public GameManager gm;
	public AudioClip sound;

	// Use this for initialization
	void Start ()
	{
		if (!gm)
		{
			gm = FindObjectOfType<GameManager>();
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.GetComponent<ObjectiveAnt>())
		{
			if (sound)
			{
				AudioSource.PlayClipAtPoint(sound, transform.position);
			}
			Destroy(other.gameObject);
		}
	}
}
