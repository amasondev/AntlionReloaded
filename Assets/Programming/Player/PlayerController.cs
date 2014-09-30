﻿using UnityEngine;
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
		// Face the mouse position
		//rigidbody2D.AddTorque(Vector2.Angle(transform.up, targetLocation - transform.position), ForceMode2D.Impulse);

		// Move towards the target location
		if (Vector3.Distance(targetLocation, transform.position) > deadZone)
		{
			Vector3 moveVector = Vector3.ClampMagnitude((targetLocation - transform.position) * vectorFactor, movement.speed);
			rigidbody2D.velocity = moveVector;
		}
	}
}

[System.Serializable]
public class Movement
{
	public float speed = 4f;
}