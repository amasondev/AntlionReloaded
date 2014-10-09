using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter))][ExecuteInEditMode]
public class AntLionGaze : MonoBehaviour
{
	public Transform left;
	public Transform right;

	MeshFilter meshFilter;

	void Start()
	{
		meshFilter = GetComponent<MeshFilter>();
	}

	void Update()
	{
		if (!left || !right)
			return;
		if (!meshFilter.sharedMesh)
			meshFilter.sharedMesh = new Mesh();

		meshFilter.sharedMesh.name = "GazeMesh";

		meshFilter.sharedMesh.vertices = new Vector3[3]
		{
			transform.localPosition,
			left.localPosition,
			right.localPosition
		};

		meshFilter.sharedMesh.uv = new Vector2[3]
		{
			new Vector2(0,0),
			new Vector2(0,1),
			new Vector2(1,1)
		};

		meshFilter.sharedMesh.triangles = new int[3]
		{
			0, 1, 2
		};

		meshFilter.sharedMesh.RecalculateNormals();
		meshFilter.sharedMesh.RecalculateBounds();

		PolygonCollider2D poly = GetComponent<PolygonCollider2D>();

		if (poly)
		{
			poly.points = new Vector2[3]
			{
				transform.localPosition,
				left.localPosition,
				right.localPosition
			};
		}
	}

	void OnTriggerStay2D (Collider2D other)
	{
		//Debug.Log("Viewing " + other.gameObject);
		if (other.GetComponent<PlayerController>())
		{
			RaycastHit2D ray = Physics2D.Raycast(transform.position, other.transform.position - transform.position, 1000f, 1);

			if (ray.collider && ray.collider.gameObject == other.gameObject)
			{
				other.SendMessage("Die");
			}
		}
	}
}
