using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuEnemy : MonoBehaviour
{
    Rigidbody2D rb;
     public float speed = 5f;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Move the object to the right
        //transform.Translate(Vector3.right * speed * Time.deltaTime);
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object has the tag "box"
        if (other.CompareTag("EnemyDespond"))
        {
            // Destroy the game object
            Destroy(gameObject);
        }
    }
}
