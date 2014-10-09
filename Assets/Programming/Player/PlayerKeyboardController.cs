using UnityEngine;
using System.Collections;

public class PlayerKeyboardController : PlayerController
{
    // Private
    Vector2 inputMovement = Vector2.zero;

    // Update is called once per frame
    void FixedUpdate()
    {
        GetInput();
        // Face the mouse position
		if (!dead)
		{
			FaceTarget();
			Movement(Time.fixedDeltaTime);
		}
    }

    void Movement (float time)
    {
        Vector2 vel = inputMovement * movement.speed;
        vel = Vector2.ClampMagnitude(vel, movement.speed);
        rigidbody2D.velocity = vel;

		anim.SetFloat ("MovementSpeed", vel.magnitude);
    }

    void GetInput()
    {
        inputMovement.y = Input.GetAxis("Vertical");
        inputMovement.x = Input.GetAxis("Horizontal");
    }
}
