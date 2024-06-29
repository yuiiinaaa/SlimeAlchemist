using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Coin", menuName = "InventorySystem/Items/Coin")]
public class CoinObject : ItemObject
{
    public int amount;
    // Start is called before the first frame update
    public void Awake(){
        type = ItemType.Coin;
    }
}
