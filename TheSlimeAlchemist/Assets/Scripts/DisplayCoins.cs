using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayCoins : MonoBehaviour
{
    public InventoryObject inventory;

    TextMeshProUGUI myText;
    // Start is called before the first frame update
    void Start()
    {
        //var obj = Instantiate(inventory.coins.prefab, this.transform);
        myText = GetComponentInChildren<TextMeshProUGUI>();
        myText.text = inventory.coinAmount.ToString("n0");
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay(); 
  
    }

    public void UpdateDisplay(){
        myText.text = inventory.coinAmount.ToString("n0");
    }
}
