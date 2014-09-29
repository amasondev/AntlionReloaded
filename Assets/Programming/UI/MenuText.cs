using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Collider))]
public class MenuText : MonoBehaviour
{
	public Color hoverColor = Color.yellow;
	private Color originalColor;
	protected TextMesh txt;

	protected void Awake()
	{
		txt = GetComponent<TextMesh>();
		originalColor = txt.color;
	}
	
	void OnMouseOver()
	{
		txt.color = hoverColor;
	}

	void OnMouseExit()
	{
		txt.color = originalColor;
	}

}