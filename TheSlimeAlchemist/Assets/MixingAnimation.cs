// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using TMPro;
// using UnityEngine.UI;

// public class RotateUIImage : MonoBehaviour
// {
//     public float rotationSpeed = 100f; // Speed of rotation in degrees per second
//     public float rotationRange = 20f; // Maximum angle to rotate

//     private RectTransform rectTransform;
//     private bool isRotatingRight = true;
//     private int rotationCount = 0;

//     void Start()
//     {
//         rectTransform = GetComponent<RectTransform>();
//         // Start the rotation coroutine
//         StartCoroutine(RotateImage());
//     }

//      IEnumerator RotateImage(){
//     while (rotationCount < 4) // Loop until 4 rotations are completed
//     {
//         //move right
//         //for (int i = 0; i < 2; i++)
//         //{
//             float startAngle = rectTransform.eulerAngles.z;
//             float targetAngle = isRotatingRight ? startAngle + rotationRange : startAngle - rotationRange;

//             // Rotate towards the target angle
//             while (rectTransform.eulerAngles.z != targetAngle)
//             {
//                 float step = rotationSpeed * Time.deltaTime;
//                 rectTransform.rotation = Quaternion.RotateTowards(rectTransform.rotation, Quaternion.Euler(0, 0, targetAngle), step);
//                 yield return null;
//             }


//             // Reverse direction
//             isRotatingRight = !isRotatingRight;
//         //}

//         rotationCount++; // Increment rotation count after completing one full rotation

//         yield return new WaitForSeconds(1f); // Wait for 1 second before changing direction
//     }
// }

// }