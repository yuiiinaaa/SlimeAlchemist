using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotAirBalloon : MonoBehaviour
{
    public float moveSpeed = 5f;  // Speed at which the player moves upward
    public float stopYPosition = 10f;  // Y position at which the player should stop

    private bool isMovingUp = false;

    public Transform balloon;

    void Update()
    {
        if (isMovingUp)
        {
            // Move the player upward
            balloon.Translate(Vector3.up * moveSpeed * Time.deltaTime);

            // Check if the player has reached the stop Y position
            if (balloon.position.y >= stopYPosition)
            {
                // Stop moving
                isMovingUp = false;
            }
        }
    }

    // When the player collides with another object
    void OnCollisionEnter2D(Collision2D collision)
    {
        //***CHANGE THIS PART OF THE CODE TO COMPARE WHEN IT IS A HELIUM SLIME***//
        //if (collision.gameObject.CompareTag("Player")) 
        //{
            // Start moving up
            isMovingUp = true;
        //}
    }
}
