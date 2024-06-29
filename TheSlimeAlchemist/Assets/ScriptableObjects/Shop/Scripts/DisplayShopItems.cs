using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
public class DisplayShopItems : MonoBehaviour
{
    public InventoryObject inventory;
    public InventoryObject shopInventory;
    public Sprite nonEnabled;

    //public GameObject fullDisplay;
    // Start is called before the first frame update
    static Dictionary<int, bool> itemEnabled = new Dictionary<int, bool>();

    private SlimeObject selectedSlime;

    public SlimeObject resetSlime;
    void Start()
    {
        itemEnabled.Clear();
        CreateDisplay(); 
        //selectedSlime = resetSlime;


    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay(); 
        //UpdateSlime();    
    }

    public void CreateDisplay()
    {
        for (int i = 0; i < shopInventory.Container.Count; i++)
        {
            var obj = Instantiate(shopInventory.Container[i].item.shopPrefab, this.transform);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = shopInventory.Container[i].item.price.ToString("n0");

            Image itemImage = obj.GetComponentsInChildren<Image>()[1];

            if(shopInventory.Container[i].item.hasBeenFound){
                if (itemImage != null){
                itemImage.sprite = shopInventory.Container[i].item.icon;
            }
            }else{
                itemImage.sprite = nonEnabled;

            }

            //if (!itemEnabled.ContainsKey(inventory.Container[i].ID)){
                itemEnabled.Add(shopInventory.Container[i].ID, shopInventory.Container[i].item.hasBeenFound);
            //}
            

            
            
        }
    }

    public void UpdateDisplay(){
        for (int i = 0; i < shopInventory.Container.Count; i++){
            if (itemEnabled.ContainsKey(shopInventory.Container[i].ID)){
                //itemEnabled[inventory.Container[i].ID].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            }else{
                var obj = Instantiate(shopInventory.Container[i].item.shopPrefab, this.transform);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = shopInventory.Container[i].item.price.ToString("n0");

                Image itemImage = obj.GetComponentsInChildren<Image>()[1];

                if(!shopInventory.Container[i].item.hasBeenFound){
                    if (itemImage != null)
                {
                    itemImage.sprite = shopInventory.Container[i].item.icon;
                }
                }
                // Use the item ID as the key
                itemEnabled.Add(shopInventory.Container[i].ID, shopInventory.Container[i].item.hasBeenFound);

                }
        }

    }

    public void SlimeFullDisplay(SlimeObject _item){
        Debug.Log($"Clicked {_item}");
        selectedSlime = _item;
        Debug.Log($"Selected Slime: {selectedSlime}");
    
    }

    // public void UpdateSlime(){
    //     //Update FullDisplay
    //     TextMeshProUGUI[] textComponents = fullDisplay.GetComponentsInChildren<TextMeshProUGUI>(includeInactive: true);

    //     if (textComponents.Length >= 3)
    //     {
    //         TextMeshProUGUI firstText = textComponents[0];
    //         TextMeshProUGUI secondText = textComponents[1];
    //         TextMeshProUGUI thirdText = textComponents[2];

    //         // Now you can access each text component
    //         firstText.text = selectedSlime.displayName;
    //         secondText.text = selectedSlime.description;
    //         thirdText.text = "Pay " + selectedSlime.price.ToString("n0")+ " Coins?";          
    //     }

    // }
    
}
