using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasers : MonoBehaviour
{
    private Renderer objectRenderer;
    public Collider2D colliderToToggle;
    private bool isVisible = true;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        InvokeRepeating("ToggleVisibility", 0f, 1.5f);
        Debug.Log("start");
    }
    void Update(){

    }
    void ToggleVisibility()
    {
        isVisible = !isVisible;
        objectRenderer.enabled = isVisible;
        if (colliderToToggle != null)
        {
            // Toggle the collider's enabled state
            colliderToToggle.enabled = !colliderToToggle.enabled;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the desired object
        if (collision.gameObject.CompareTag("Player"))
        {
           Debug.Log("contact");
        }
    }
}