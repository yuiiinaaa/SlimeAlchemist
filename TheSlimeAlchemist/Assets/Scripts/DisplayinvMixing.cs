using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class DisplayInventoryMixing : MonoBehaviour
{
    public InventoryObject inventory;
    public InventoryObject partyInventory;

    // Change the dictionary to be more flexible
    static Dictionary<int, GameObject> itemsDisplayed = new Dictionary<int, GameObject>();


    private static bool playInvOut;
    private Image parentImage;

    void Start()
    {
        //...
        itemsDisplayed.Clear();
        playInvOut = false;

        CreateDisplay();
        parentImage = GetComponent<Image>();
    }

    void Update()
    { 
        UpdateDisplay(); 

    }



    public void CreateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            var obj = Instantiate(inventory.Container[i].item.MixingPrefab, this.transform);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");

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
                var obj = Instantiate(inventory.Container[i].item.MixingPrefab, this.transform);
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

    

    public void AddToParty(SlimeObject _item){
        //Debug.Log("CURRENT OUT STATUS" + playInvOut);


        
            if (_item != null && inventory.Container.Any(slot => slot.item == _item))
        {
            //Debug.Log("Adding to Player INV");
            InventorySlot inventorySlot = inventory.Container.Find(slot => slot.item == _item);
            

            partyInventory.AddItem(_item, 1);
            inventory.RemoveItem(_item, 1);
            _item.inParty = true;
            // Remove the item from the dictionary
            itemsDisplayed.Remove(inventorySlot.ID);


            //CURRENTLY BROKEN
            //if the party size is full
            if(partyInventory.Container.Count > partyInventory.maxSlimes){
                inventory.AddItem(partyInventory.Container[0].item, 1);
                partyInventory.RemoveItem(partyInventory.Container[0].item, 1);
                partyInventory.Container[0].item.inParty = false;
                
                
                //Destroy prefab from the party
                
            }

            // // Debug.Log items and keys from the dictionary
            //  Debug.Log("Dictionary Contents:");

            //  foreach (var kvp in itemsDisplayed){
            //      Debug.Log($"Key: {kvp.Key}, Item: {kvp.Value}");
            // }
            
        }else if (_item != null && partyInventory.Container.Any(slot => slot.item == _item)){
            Debug.Log("Adding to PARTY INV");
     
            inventory.AddItem(_item, 1);
            partyInventory.RemoveItem(_item, 1);
            _item.inParty = false;
            }
    }
}
