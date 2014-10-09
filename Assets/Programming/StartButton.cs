using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour
{
	public Animator anim;

	// Use this for initialization
	void Start()
	{
		if (!anim) anim = GetComponent<Animator>();
	}

	void OnMouseOver()
	{
		anim.SetBool("MouseOver", true);
	}

	void OnMouseExit()
	{
		anim.SetBool("MouseOver", false);
	}

	void OnMouseUpAsButton()
	{
		DontDestroyOnLoad(GameObject.Find("Music"));
		Application.LoadLevel(1);
	}
}
