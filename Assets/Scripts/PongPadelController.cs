using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongPadelController : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;

    public float upperLimit = 4.3f;  // Adjust this value as needed
    public float lowerLimit = -4.3f;  // Adjust this value as needed

    private float moveInput;

    void Update()
    {
        // Get the vertical input
        moveInput = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        // Calculate the desired movement
        Vector2 movement = new Vector2(0, moveInput) * speed * Time.fixedDeltaTime;
        Vector2 newPosition = rb.position + movement;

        // Clamp the position to the defined limits
        newPosition.y = Mathf.Clamp(newPosition.y, lowerLimit, upperLimit);

        // Move the paddle to the new position
        rb.MovePosition(newPosition);
    }
}