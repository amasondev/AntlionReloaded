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
            grabbed.velocity = ((Vector2)p.targetLocation - prevGrabbedPos)* throwStrength;
            grabbed = null;
        }

        if (grabbed)
        {
            prevGrabbedPos = p.targetLocation;
            grabbed.MovePosition(transform.position + (p.targetLocation - transform.position).normalized * distance);
        }
    }

    void Grab()
    {
        Debug.Log("Grab!");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, p.targetLocation - transform.position, distance);
        if (hit && hit.collider.rigidbody2D)
        {
            Debug.Log("Grabbed " + hit.collider.gameObject);
            grabbed = hit.collider.rigidbody2D;
        }
    }
}
