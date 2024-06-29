using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType{
    Slime,
    Coin,
    Default
}

[CreateAssetMenu(fileName = "default", menuName = "InventorySystem/Items/Default")]
public abstract class ItemObject : ScriptableObject{
    public int ID;
    public string displayName;
    public Sprite icon;
    public GameObject prefab;
    public GameObject shopPrefab;
    public GameObject MixingPrefab;
    public GameObject playableCharacter;
    public ItemType type;
    [TextArea(15,20)]
    public string description;
    public bool inParty = false;

    public bool hasBeenFound;
    public int price;
    public List<string> recipeList = new List<string>();

}
