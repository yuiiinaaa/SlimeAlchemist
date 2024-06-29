using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
public class ItemInfoDis : MonoBehaviour
{
    private static TextMeshProUGUI[] textComponents;
    public static SlimeObject selectedSlime;

    private static Image itemImage;
    public SlimeObject badSlime;

    public InventoryObject playerinventory;

    private bool enab;
    // Start is called before the first frame update
    void Start()
    {
        itemImage = GetComponentsInChildren<Image>()[1];
        selectedSlime = badSlime;
        itemImage.sprite = selectedSlime.icon;

        textComponents = GetComponentsInChildren<TextMeshProUGUI>();


        TextMeshProUGUI firstText = textComponents[0];
        TextMeshProUGUI secondText = textComponents[1];
        TextMeshProUGUI thirdText = textComponents[2];

        
        firstText.text = "Name";
        secondText.text = "   ";
        thirdText.text = "Price"; 
        enab = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (selectedSlime.hasBeenFound){
        if (textComponents.Length >= 3)
        {
            TextMeshProUGUI firstText = textComponents[0];
            TextMeshProUGUI secondText = textComponents[1];
            TextMeshProUGUI thirdText = textComponents[2];

            // Now you can access each text component
            firstText.text = selectedSlime.displayName;
            secondText.text = selectedSlime.description;
            if(enab){
            thirdText.text = "Pay " + selectedSlime.price.ToString("n0")+ " Coins?"; 
            }else{
                thirdText.text = " "; 
            }         
        }
        }else{
            TextMeshProUGUI firstText = textComponents[0];
            TextMeshProUGUI secondText = textComponents[1];
            TextMeshProUGUI thirdText = textComponents[2];

            // Now you can access each text component
            firstText.text = "Mystery Slime";
            secondText.text = "This slime has yet to be found! You must enounter it in a level before you can buy it.";
            thirdText.text = " "; 

        }

        
    }

    public void UpdateSlime(SlimeObject _item){
        selectedSlime = _item;
        TextMeshProUGUI fourthText = textComponents[3];
        fourthText.text = "   ";
        enab = true;
        itemImage.sprite = selectedSlime.icon;
    }

    public void BuySlime(){
        TextMeshProUGUI fourthText = textComponents[3];
        

        if (selectedSlime.hasBeenFound){
            int setPrice = selectedSlime.price;

            if(playerinventory.coinAmount-setPrice >= 0){
                playerinventory.AddItem(selectedSlime, 1);
                playerinventory.coinAmount -= setPrice;
            }else{
                enab = false;
                fourthText.text = "You don't have enough coins!";
            }
        }
        else{
            fourthText.text = "You can't buy this!"; 
        }
    }
}
