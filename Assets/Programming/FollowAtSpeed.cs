using UnityEngine;
using System.Collections;

public class FollowAtSpeed : MonoBehaviour
{
    // Public
    // Speed to follow the object
    public float speed = 1f;
    // Target to follow
    public Transform target;
    // Lock Axes
    public bool lockX = false;
    public bool lockY = false;
    public bool lockZ = false;


    // Update is called once per frame
    void LateUpdate()
    {
        if (target)
        {
            Vector3 newLoc = Vector3.Lerp(transform.position, target.position, speed * Time.deltaTime);
            if (lockX)
            {
                newLoc.x = transform.position.x;
            }
            if (lockY)
            {
                newLoc.y = transform.position.y;
            }
            if (lockZ)
            {
                newLoc.z = transform.position.z;
            }

            transform.position = newLoc;
        }
    }
}
