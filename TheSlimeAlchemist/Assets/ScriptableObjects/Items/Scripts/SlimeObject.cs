using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Slime", menuName = "InventorySystem/Items/Slimes")]
public class SlimeObject : ItemObject
{
    public string ability;
    //public int price;
    public float rarity;
    //public bool inParty;
    // Start is called before the first frame update
    public void Awake(){
        type = ItemType.Slime;
    }
}
