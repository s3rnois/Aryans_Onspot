using UnityEngine;

public class Restart1 : MonoBehaviour
{
    private Vector3 originalPosition;

    void Start()
    {
        // Save the starting position of the cube
        originalPosition = transform.position;
    }

    void onCollisionEnter(Collision col)
    {
        // Check if the collided object is named "Cube1"
        if (col.gameObject.name != "enemy")
        {
            // Reset position to the original starting position
            transform.position = originalPosition;

            // Optional: Reset velocity if using Rigidbody
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }
}

