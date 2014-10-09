using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
	// Public
	// Container for movement variables
	public Movement movement = new Movement();
    // Whether we follow the mouse or not
    public bool followMouse = true;
    // Reference to camera in the scene
    public Camera cam;
	// Reference to the animator
	public Animator anim;

    // Location to move to
    [System.NonSerialized]
    public Vector3 targetLocation = Vector3.zero;

	// Use this for initialization
	protected void Start()
	{
		if (!anim)
		{
			anim = GetComponentInChildren<Animator>();
		}

        if (!cam)
        {
            cam = Camera.main;
            targetLocation = transform.position;
        }
	}

    protected void Update()
    {
        if (Input.mousePresent && followMouse)
        {
            // Target location is the mouse position
            targetLocation = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            targetLocation.z = 0;
        }
    }

    protected void FaceTarget()
    {
        // Face the mouse position
        Quaternion newRot = Quaternion.LookRotation(transform.forward, targetLocation - transform.position);
        transform.rotation = newRot;
    }
}

[System.Serializable]
public class Movement
{
	public float speed = 4f;
	public float friction = 2f;
}