using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltMountain : MonoBehaviour
{
    Rigidbody2D rb;
    //BoxCollider2D bc;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name + "collided");

        //if it collides with water it disappears LOL
        if (collision.gameObject.name == "Player")
        {
            Destroy(gameObject);

        }

    }
}
