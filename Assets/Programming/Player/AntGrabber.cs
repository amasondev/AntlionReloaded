using UnityEngine;
using System.Collections;

public class AntGrabber : MonoBehaviour
{
    public float distance = 1f;
    public float throwStrength = 10f;
    
    private PlayerController p;
    private Rigidbody2D grabbed;
    private Vector2 prevGrabbedPos = Vector2.zero;

    void Start()
    {
        p = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (p && Input.GetButtonDown("Fire1"))
        {
            Grab();
        }

        if (!Input.GetButton("Fire1") && grabbed)
        {
			Physics2D.IgnoreCollision(grabbed.collider2D, this.collider2D, false);
            grabbed.velocity = ((Vector2)p.targetLocation - prevGrabbedPos)* throwStrength;
            grabbed = null;
        }
    }

	void FixedUpdate()
	{
		if (grabbed)
		{
			Physics2D.IgnoreCollision(grabbed.collider2D, this.collider2D);
			prevGrabbedPos = p.targetLocation;
			Vector2 newPos = transform.position + Vector3.ClampMagnitude(p.targetLocation - transform.position, distance);

			grabbed.MovePosition(newPos);
		}
	}

    void Grab()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, p.targetLocation - transform.position, distance);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit && hit.collider.rigidbody2D && hit.collider.GetComponent<ObjectiveAnt>())
            {
                grabbed = hit.collider.rigidbody2D;
            }
        }
    }
}
