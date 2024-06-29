using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;


public class DestroyObjectAndChildren : MonoBehaviour
{
    public void DestroyObjectWithChildren()
    {
        // Check if any child has a text input component
        bool shouldDestroy = true;



        string myText = transform.GetComponentInChildren<TextMeshProUGUI>().text;

        //Debug.Log(myText);

        //int number = int.Parse(myText);

        //if(number <=1){
            // Destroy all children of the current GameObject
        foreach (Transform child in transform){
            Destroy(child.gameObject);
        }
        // Destroy the current GameObject
        Destroy(gameObject);
       // }

    }
}
