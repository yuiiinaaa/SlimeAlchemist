using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVelocityController : MonoBehaviour
{
    Rigidbody2D rb;
    public Vector2 inputDirection;
    public bool jump;
    public float runVelocity;
    public float maxVelocity;
    public float jumpForce;
    public float deaccelerationMultiplier;
    public bool isGrounded;
    public float groundDetectionRange;
    public LayerMask groundLayers;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (jump && isGrounded)
            Jump();
    }

    private void FixedUpdate()
    {
        GroundDetection();
        FlipBehaviour();
        MovementBehaviour();
    }
    void FlipBehaviour()
    {
        //If there is a input, flip the scale to that direction
        if (inputDirection.x != 0)
        {
            Vector3 theScale = transform.localScale;
            theScale.x = Mathf.Abs(theScale.x) * Mathf.Sign(inputDirection.x);
            transform.localScale = theScale;
        }
    }
    void GroundDetection()
    {
        RaycastHit2D groundHit = Physics2D.Raycast(transform.position, Vector2.down, groundDetectionRange, groundLayers);

        //Debug.Log("Player Down Velocity:" + rb.velocity.y);

        isGrounded = (groundHit.collider != null && rb.velocity.y <= 0);
    }

    void MovementBehaviour()
    {
        if (inputDirection.x != 0)
        {
            rb.velocity = new Vector2(inputDirection.x * runVelocity, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x * deaccelerationMultiplier, rb.velocity.y);
        }
    }

    void Jump()
    {
        jump = false;
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
