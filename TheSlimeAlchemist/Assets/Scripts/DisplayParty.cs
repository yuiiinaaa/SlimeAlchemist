using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;


public class DisplayParty : MonoBehaviour
{
    public InventoryObject inventory;
    public InventoryObject otherInventory;
    static Dictionary<int, GameObject> itemsDisplayed = new Dictionary<int, GameObject>();

    public GameObject playerSlot1;

    // Start is called before the first frame update
    void Start()
    {
        itemsDisplayed.Clear();
        CreateDisplay();
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay(); 
        
    }

    public void CreateDisplay(){
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            //inventory.Container[i].item.prefab = playerSlot1;

            var obj = Instantiate(inventory.Container[i].item.prefab, this.transform);
            //obj.GetComponent<Transform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = "  ";

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
    // Create a list to store keys (IDs) to remove
    List<int> keysToRemove = new List<int>();

    // Iterate through the existing itemsDisplayed dictionary
    foreach (var kvp in itemsDisplayed)
    {
        // Check if the corresponding inventory slot exists and has a non-zero amount
        bool slotExists = inventory.Container.Any(slot => slot.ID == kvp.Key && slot.amount > 0);

        // If the game object is null or the corresponding inventory slot doesn't exist, mark for removal
        if (kvp.Value == null || !slotExists)
        {
            keysToRemove.Add(kvp.Key);
        }
    }

    // Remove items outside the loop
    foreach (int key in keysToRemove)
    {
        Destroy(itemsDisplayed[key]); // Destroy the game object
        itemsDisplayed.Remove(key);   // Remove the key from the dictionary
    }

    // Iterate through the inventory to update or instantiate new game objects
    for (int i = 0; i < inventory.Container.Count; i++)
    {
        if (itemsDisplayed.ContainsKey(inventory.Container[i].ID) && inventory.Container[i].amount > 0)
        {
            // Update the existing game object
            itemsDisplayed[inventory.Container[i].ID].GetComponentInChildren<TextMeshProUGUI>().text = "  ";
        }
        else
        {
            // Instantiate a new game object
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

}
