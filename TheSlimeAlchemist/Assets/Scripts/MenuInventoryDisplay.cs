using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;


public class MenuInventoryDisplay : MonoBehaviour
{
    public InventoryObject inventory;
    static Dictionary<int, GameObject> itemsDisplayed = new Dictionary<int, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        itemsDisplayed.Clear();
        CreateDisplay();
        //parentImage = GetComponent<Image>();
    }

    void Update()
    { 
        //ClearDictionaryIfNotScene();
        UpdateDisplay(); 
   
    }

    public void CreateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            var obj = Instantiate(inventory.Container[i].item.prefab, this.transform);

            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");

            Button buttonComponent = obj.GetComponent<Button>();

            // Check if the Button component is not null
            if (buttonComponent != null)
            {
                buttonComponent.interactable = false;
            }

            Image itemImage = obj.GetComponentsInChildren<Image>()[1];
            if (itemImage != null)
            {
                itemImage.sprite = inventory.Container[i].item.icon;
            }

            // Use the item ID as the key
            itemsDisplayed.Add(inventory.Container[i].ID, obj);
        }
    }

    public void UpdateDisplay()
    {
        //Debug.Log("Updating party Display");

        for (int i = 0; i < inventory.Container.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(inventory.Container[i].ID))
            {
                itemsDisplayed[inventory.Container[i].ID].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            }
            else
            {
                var obj = Instantiate(inventory.Container[i].item.prefab, this.transform);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
                Image itemImage = obj.GetComponentsInChildren<Image>()[1];
                if (itemImage != null)
                {
                    itemImage.sprite = inventory.Container[i].item.icon;
                }
                
                itemsDisplayed.Add(inventory.Container[i].ID, obj);
            }
        }
    }

    public void ClearDictionaryIfNotScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Check if the current scene is not "InventoryScreen"
        if (currentSceneName != "InventoryScreen")
        {
            // Clear the dictionary
            itemsDisplayed.Clear();
        }
    }
}
