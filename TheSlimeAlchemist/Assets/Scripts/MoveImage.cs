using UnityEngine;
using UnityEngine.UI;

public class ParentMove : MonoBehaviour
{
    public float moveDistance = 200f; // Adjust this value as needed
    public float moveSpeed = 800f; // Adjust this value as needed

    private Vector2 originalPosition;
    private bool isMoving;

    private bool isoutside;

    void Start()
    {
        // Save the original position
        originalPosition = GetComponent<RectTransform>().anchoredPosition;
        
        isMoving = false;
        isoutside = false;

    }

    void Update()
    {
        //can click on tab or hit the P button
        if (Input.GetKeyDown(KeyCode.P)){
            isMoving = !isMoving;
            isoutside = !isoutside;
        }
        // Check if the object is currently moving
        if (isMoving)
        {
            // Move the object towards the target position
            MoveObject();
        }
    }

    void MoveObject()
    {
        Vector2 targetPosition;
        // Calculate the target position for movement
        if(isoutside){
            targetPosition = originalPosition + Vector2.right * moveDistance;
        }else{
            targetPosition = originalPosition;
        }
        
        // Move the object
        GetComponent<RectTransform>().anchoredPosition = Vector2.MoveTowards(
            GetComponent<RectTransform>().anchoredPosition, targetPosition, moveSpeed * Time.deltaTime
        );

        // Check if the object reached the target position
        if (Vector2.Distance(GetComponent<RectTransform>().anchoredPosition, targetPosition) < 0.1f)
        {
            // Stop moving
            isMoving = false;
            // Reset position to the original
            //GetComponent<RectTransform>().anchoredPosition = originalPosition;
        }
    }

    public void OnButtonClick()
    {
        // Toggle the moving state
        isMoving = !isMoving;
        isoutside = !isoutside;
    }
}
