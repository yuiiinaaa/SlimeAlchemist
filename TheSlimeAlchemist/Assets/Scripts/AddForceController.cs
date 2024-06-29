using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceController : MonoBehaviour
{
    Rigidbody2D rb;
    public Vector2 inputDirection;
    public bool jump;
    public float runForce;
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
        Movement();
    }

    void GroundDetection()
    {
        RaycastHit2D groundHit = Physics2D.Raycast(transform.position, Vector2.down, groundDetectionRange, groundLayers);

        isGrounded = (groundHit.collider != null && rb.velocity.y <= 0);
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

    void Movement()
    {
        if (inputDirection.x != 0)
        {
            rb.AddForce(Vector2.right * inputDirection.x * runForce, ForceMode2D.Force);
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x * deaccelerationMultiplier, rb.velocity.y);
        }

        //Limit max velocity
        Vector2 tempVelocity = rb.velocity;
        tempVelocity.x = Mathf.Clamp(rb.velocity.x, -maxVelocity, maxVelocity);
        rb.velocity = tempVelocity;
    }

    void Jump()
    {
        jump = false;
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
