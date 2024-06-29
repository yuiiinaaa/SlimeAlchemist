using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe Database", menuName = "InventorySystem/Items/Database")]
public class RecipeDatabaseObject : ScriptableObject, ISerializationCallbackReceiver
{
    public ItemObject[] Items;
    public Dictionary<ItemObject, int> GetId = new Dictionary<ItemObject, int>();
    public Dictionary<int, ItemObject> GetItem = new Dictionary<int, ItemObject>();
    public Dictionary<int, List<string>> GetRecipe = new Dictionary<int, List<string>>();

    public void OnAfterDeserialize(){
        GetId = new Dictionary<ItemObject, int>();
        GetItem = new Dictionary<int, ItemObject>();
        for (int i = 0; i < Items.Length; i++){
            GetId.Add(Items[i], i);
            GetItem.Add(i, Items[i]);
        }

    }
    public void OnBeforeSerialize(){

    }
}

