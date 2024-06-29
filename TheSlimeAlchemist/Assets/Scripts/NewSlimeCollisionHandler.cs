using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSlimeCollisionHandler : MonoBehaviour
{
    // Called when collision is detected

    public GameObject displayObject;
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the other collider belongs to the sprite you want to collide with
        if (other.CompareTag("Player"))
        {
            // Activate the display object
            displayObject.SetActive(true);
        }
    }

    // Called when the collision ends
    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the other collider belongs to the sprite you want to collide with
        if (other.CompareTag("Player"))
        {
            // Deactivate the display object
            displayObject.SetActive(false);
        }
    }
}
