using UnityEngine;

public class ButtonMoveParent : MonoBehaviour
{
    public float moveDistance = 2f;
    public float moveSpeed = 5f;

    private Vector3 originalPosition;
    private bool isMoving = false;

    void Start()
    {
        // Save the original position of the parent object
        originalPosition = transform.parent.position;
    }

    void Update()
    {
        // Check if the parent object is currently moving
        if (isMoving)
        {
            // Move the parent object towards the target position
            MoveParent();
        }
    }

    void MoveParent()
    {
        // Calculate the target position for movement
        Vector3 targetPosition = isMoving ? originalPosition + Vector3.right * moveDistance : originalPosition;

        // Move the parent object
        transform.parent.position = Vector3.MoveTowards(transform.parent.position, targetPosition, moveSpeed * Time.deltaTime);

        // Check if the parent object reached the target position
        if (Vector3.Distance(transform.parent.position, targetPosition) < 0.1f)
        {
            // Stop moving
            isMoving = false;
        }
    }

    public void OnButtonClick()
    {
        // Toggle the moving state
        isMoving = !isMoving;
    }
}
