using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMouseController : PlayerController
{
	// Public
	// At what distance to ignore mouse position
	public float deadZone = 0.2f;
	// Movement vector is scaled by this so we decelerate closer to the mouse
	public float vectorFactor = 3f;

    protected new void Start()
    {
        base.Start();
    }


	// Update is called once per frame
	void FixedUpdate()
	{
		if (dead)
			return;

		// Move towards the target location
		if (Vector3.Distance(targetLocation, transform.position) > deadZone)
		{
			// Face the mouse position
            FaceTarget();

			Vector3 moveVector = Vector3.ClampMagnitude((targetLocation - transform.position) * vectorFactor, movement.speed);
			rigidbody2D.velocity = moveVector;
		}
		else
		{
            rigidbody2D.velocity *= (1f / movement.friction) * Time.fixedDeltaTime;
		}
	}
}