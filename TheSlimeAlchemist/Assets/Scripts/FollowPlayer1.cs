using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer1 : MonoBehaviour
{
    public Transform target; // The player game object to follow
    public float smoothSpeed = 0.125f; // Speed of camera movement
    public Vector3 offset; // Offset from the player's position

    private void FixedUpdate()
    {
        if (target != null)
        {
            // Calculate the desired position for the camera
            Vector3 desiredPosition = target.position + offset;

            // Smoothly move the camera towards the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Update the camera's position
            transform.position = smoothedPosition;

            // Make sure the camera is always looking at the player
            transform.LookAt(target);
        }
    }
}
