using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {
	// Number of wall segments
	[Range(1, 20)]
	public int segments = 1;
	public Material mat;
	public Sprite topSprite;
	public Sprite middleSprite;
	public Sprite bottomSprite;

	// Use this for initialization
	void OnValidate ()
	{
		// Destroy children
		for (int i=0; i < transform.childCount; i++)
		{
			UnityEditor.EditorApplication.delayCall+=()=>
			{
				//DestroyImmediate(transform.GetChild(i).gameObject);
			}
		}

		if (!topSprite || !bottomSprite || !middleSprite || !mat)
		{
			return;
		}

		// Create sprites
		// Top sprite
		GameObject top = new GameObject ("top");
		top.transform.parent = transform;
		SpriteRenderer t_rnd = top.AddComponent<SpriteRenderer> ();
		t_rnd.sprite = topSprite;
		t_rnd.material = mat;
		top.transform.localPosition = Vector3.zero;

		// Middle sprites
		for (int j=0; j < segments; j++)
		{
			GameObject mid = new GameObject ("mid");
			mid.transform.parent = transform;
			SpriteRenderer m_rnd = mid.AddComponent<SpriteRenderer> ();
			m_rnd.sprite = middleSprite;
			m_rnd.material = mat;
			mid.transform.localPosition = new Vector3(middleSprite.rect.width * j, 0, 0);
		}

		// Bottom sprite
		GameObject bottom = new GameObject ("bottom");
		bottom.transform.parent = transform;
		SpriteRenderer b_rnd = bottom.AddComponent<SpriteRenderer> ();
		b_rnd.sprite = topSprite;
		b_rnd.material = mat;
		bottom.transform.localPosition = new Vector3 (bottomSprite.rect.width * segments, 0, 0);
	}
}
