using UnityEngine;
using System.Collections;

public class MenuCamera : MonoBehaviour
{
	public float speed = 5f;
	
	public void GoToMenu(Transform location)
	{
		StopCoroutine("movement");
		StartCoroutine("movement", location);
	}

	IEnumerator movement (Transform location)
	{
		while (Vector3.Distance(transform.position, location.position) > 0.01f)
		{
			Vector3 movementVector = Vector3.Lerp(transform.position, location.position, Time.deltaTime * speed);
			transform.position = movementVector;

			transform.rotation = Quaternion.Lerp(transform.rotation, location.rotation, Time.deltaTime * speed);

			yield return null;
		}
	}
}