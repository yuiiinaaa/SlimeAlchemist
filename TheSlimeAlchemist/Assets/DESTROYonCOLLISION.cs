using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public string collisionTag = "YourTag"; // Set the tag to the one you want to detect collisions with

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision);
        // Check if the colliding object has the specified tag
        if (collision.gameObject.CompareTag(collisionTag))
        {
            // Destroy the game object this script is attached to
            Destroy(gameObject);
        }
    }
}
