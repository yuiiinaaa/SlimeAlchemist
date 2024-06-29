using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 5f;
    public Vector2 inputDirection;

    

    void Update()
    {
        inputDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // Rotate left when A key is pressed
        if (inputDirection.x < 0)
        {
            RotateObjectLeft();
        }

        // Rotate right when D key is pressed
        if (inputDirection.x > 0)
        {
            RotateObjectRight();
        }
    }

    void RotateObjectLeft()
    {
        // Rotate the object around its up axis
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    void RotateObjectRight()
    {
        // Rotate the object around its up axis in the opposite direction
        transform.Rotate(Vector3.forward * -rotationSpeed * Time.deltaTime);
    }
}