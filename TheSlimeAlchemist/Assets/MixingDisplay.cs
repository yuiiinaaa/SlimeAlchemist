using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class MixingDisplay : MonoBehaviour
{
    public InventoryObject mixingInventory;
    public InventoryObject inventory;
    public InventoryObject recipeInventory;

    static List<GameObject> childSlots = new List<GameObject>();
    static Dictionary<int, GameObject> itemsDisplayed = new Dictionary<int, GameObject>();

    public GameObject icon;
    public GameObject popUpWindow;

    private GameObject obj;
    private bool popUP = false;

    static List<string> recipes = new List<string>();

    void Start()
    {
        recipes.Clear();
        childSlots.Clear();
        ResetMixingInventory();

        // Iterate through all children of the parent object
        foreach (Transform child in transform)
        {
             childSlots.Add(child.gameObject);      
        }
        //Debug.Log(childSlots.Count);
    }

    void Update(){
        
        for (int i = 0; (i < childSlots.Count) && (i < mixingInventory.Container.Count); i++){
            // Check if the item is present in the mixing inventory and has a positive amount
            if (mixingInventory.Container[i].item != null && mixingInventory.Container[i].amount > 0)
            {
                // Check if the item is already displayed
                if (!itemsDisplayed.ContainsKey(i)){
                    // Instantiate the icon and set it as a child of the corresponding child slot
                    GameObject obj = Instantiate(icon, childSlots[i].transform);
                    Image itemImage = obj.GetComponent<Image>(); // Get the Image component of the instantiated icon
                    obj.GetComponentInChildren<TextMeshProUGUI>().text = mixingInventory.Container[i].amount.ToString("n0");
                    
                    if (itemImage != null)
                    {
                        itemImage.sprite = mixingInventory.Container[i].item.icon;
                    }

                    // Add the instantiated icon to the dictionary with the corresponding index
                    itemsDisplayed.Add(i, obj);
                } else{

                    itemsDisplayed[i].GetComponentInChildren<TextMeshProUGUI>().text = mixingInventory.Container[i].amount.ToString("n0");

                }
            }
            
      
        }
    }

    public void ResetMixingInventory(){
        // Move items from mixing inventory to inventory
        foreach (InventorySlot slot in mixingInventory.Container)
        {
            inventory.AddItem(slot.item, slot.amount); // Add item to inventory
        }
        mixingInventory.Container.Clear(); // Clear mixing inventory



        // Clear the dictionary
        foreach (var kvp in itemsDisplayed)
        {
            Destroy(kvp.Value); // Destroy the displayed item GameObject
        }
        itemsDisplayed.Clear(); // Clear the dictionary

    }

    public void MixRecipe(){
        //recipes could be a dictionary of items and combo codes

        for (int i = 0;i < mixingInventory.Container.Count; i++){
            int tempAmount = mixingInventory.Container[i].amount;

            Debug.Log("temp amount " + tempAmount);

            while(tempAmount>=1){
                recipes.Add(mixingInventory.Container[i].item.displayName);
                tempAmount--;
            }

        }

        foreach (string name in recipes){
                Debug.Log("recipe item inv: " + name);
                }

        //Debugging purposes

        //after mixing, remove the items from the mixing inventory and 
        //add mixed slime to the players inventory if there is a match
        //maybe add a popup screen?
        //if recipe does not match, will get a notification that the mixing has failed

        //Maybe add a price for each time you "mix"

        //check through each of the recipes?
        for (int i = 0; i < recipeInventory.Container.Count; i++){

            Debug.Log("enterLoop");

            //check if there is the right amount of ingredients
            if(recipes.Count == recipeInventory.Container[i].item.recipeList.Count){

                List<string> templist = new List<string>();           
                foreach (string name in recipeInventory.Container[i].item.recipeList){
                    templist.Add(name);
                    Debug.Log("Recipe name" + i +" "+ name);
                }

                foreach (string name in recipes){
                    if(templist.Contains(name)){
                        templist.Remove(name);
                    }
                }

                //DEBUG
                foreach (string name in templist){
                    Debug.Log("temp item " + name);
                    
                }

                //if all the items match, add the crafted item to the player's inventory
                if(templist.Count == 0){
                    CreatePopup(recipeInventory.Container[i].item);
                    inventory.AddItem(recipeInventory.Container[i].item, 1); 
                    
                }else{
                    Debug.Log("MIXING FAILED HAHA");
                    CreatePopup(null);
                }     

            }else{
                    Debug.Log("MIXING FAILED HAHA??");
                    CreatePopup(null);
            }             
        }

        mixingInventory.Container.Clear(); // Clear mixing inventory
        // Clear the dictionary
        foreach (var kvp in itemsDisplayed)
        {
            Destroy(kvp.Value); // Destroy the displayed item GameObject
        }
        itemsDisplayed.Clear(); // Clear the dictionary
         recipes.Clear(); //clear recipe list

    }

    void CreatePopup(ItemObject selectedSlime){
        
        obj = Instantiate(popUpWindow, transform);
        TextMeshProUGUI[] textComponents = obj.GetComponentsInChildren<TextMeshProUGUI>();
        Image itemImage = obj.GetComponentsInChildren<Image>()[2];

        TextMeshProUGUI firstText = textComponents[0];
        TextMeshProUGUI secondText = textComponents[1];

        if(selectedSlime != null){
            firstText.text = selectedSlime.displayName;
            secondText.text = selectedSlime.description;
            itemImage.sprite = selectedSlime.icon;
        }else{
            firstText.text = "FAILURE!";
            secondText.text = "This is a useless slime that will be sacrificed to the biohazard bin.";
        }

    }
    
    void OnApplicationQuit(){
        ResetMixingInventory();
    }




    //  int iconCounter = 0;
    //     int tempAmount = mixingInventory.Container[i].item.amount;

    //     for (int i = 0; i < mixingInventory.Container.Count && i < childImages.Count; i++)
    //     {
    //         Image itemImage = childSlots[i].GetComponentsInChildren<Image>()[1];
            
    //         if(tempAmount > 1){
                
    //         }
    //         // Check if the item has an icon before assigning it
    //         if (mixingInventory.Container[i].item.icon != null)
    //         {
    //             imageComponent.sprite = mixingInventory.Container[i].item.icon;
    //         }
    //     }
}
