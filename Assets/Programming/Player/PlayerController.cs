using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
	// Public
	// Whether we follow the mouse or not
	public bool followMouse = true;
	// Container for movement variables
	public Movement movement = new Movement();
	// At what distance to ignore mouse position
	public float deadZone = 0.2f;
	// Movement vector is scaled by this so we decelerate closer to the mouse
	public float vectorFactor = 3f;
	// Reference to camera in the scene
	public Camera cam;

	// Private
	// Location to move to
	private Vector3 targetLocation = Vector3.zero;

	// Use this for initialization
	void Start()
	{
		if (!cam)
		{
			cam = Camera.main;
			targetLocation = transform.position;
		}
	}

	void Update()
	{
		if (Input.mousePresent && followMouse)
		{
			// Target location is the mouse position
			targetLocation = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
			targetLocation.z = 0;
		}
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		// Move towards the target location
		if (Vector3.Distance(targetLocation, transform.position) > deadZone)
		{
			// Face the mouse position
			Quaternion newRot = Quaternion.LookRotation(transform.forward, targetLocation - transform.position);
			transform.rotation = newRot;

			Vector3 moveVector = Vector3.ClampMagnitude((targetLocation - transform.position) * vectorFactor, movement.speed);
			rigidbody2D.velocity = moveVector;
		}
		else
		{
			rigidbody2D.velocity *= (1f / movement.friction) * Time.fixedDeltaTime;
		}
	}
}

[System.Serializable]
public class Movement
{
	public float speed = 4f;
	public float friction = 2f;
}