using UnityEngine;
using System.Collections;

public class NavMenuText : MenuText
{
	public Transform menuTransform;

	private MenuCamera cam;
	protected new void Awake()
	{
		base.Awake();
		cam = FindObjectOfType<MenuCamera>();
	}

	protected void OnMouseUpAsButton()
	{
		if (cam)
		{
			cam.GoToMenu(menuTransform);
		} else {
			Debug.Log("No menu camera found.");
		}
	}
}
