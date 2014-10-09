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

	protected bool dead = false;

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

		if (dead && Input.GetButton("Fire1"))
		{
			Application.LoadLevel(Application.loadedLevel);
		}
    }

    protected void FaceTarget()
    {
        // Face the mouse position
        Quaternion newRot = Quaternion.LookRotation(transform.forward, targetLocation - transform.position);
        transform.rotation = newRot;
    }

	void Die ()
	{
		anim.enabled = false;
		for (int i = 0; i < transform.childCount; i++)
		{
			Transform child1 = transform.GetChild(i);

			for (int j = 0; j < child1.childCount; j++)
			{
				child1.GetChild(j).parent = transform;
			}
		}

		for (int k = 0; k < transform.childCount; k++)
		{
			Transform child2 = transform.GetChild(k);
			if (!child2.gameObject.GetComponent<Rigidbody2D>())
			{
				child2.gameObject.AddComponent<BoxCollider2D>();
				child2.gameObject.AddComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(0, 10f), Random.Range(0, 10f)));
			}
		}
		transform.DetachChildren();
		GetComponent<AntGrabber>().enabled = false;
		dead = true;
	}
}

[System.Serializable]
public class Movement
{
	public float speed = 4f;
	public float friction = 2f;
}