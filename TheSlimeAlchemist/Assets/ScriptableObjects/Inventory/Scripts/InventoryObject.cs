using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;
using System.Runtime.Serialization;

[CreateAssetMenu(fileName = "New Inventory", menuName = "InventorySystem/Inventory")]
public class InventoryObject : ScriptableObject, ISerializationCallbackReceiver
{
    public string savePath;
    public ItemDatabaseObject database;
    public ItemObject coins;
    public int coinAmount = 0;
    public List<InventorySlot> Container = new List<InventorySlot>();
    public int maxSlimes;

    public void AddCoinAmount(int value){
        coinAmount += value;
    }
    public void AddItem(ItemObject _item, int _amount){
        for(int i = 0; i < Container.Count; i++){

            if(Container[i].item == _item){
                Container[i].AddAmount(_amount);
                return;
            }       
        }

        if (_item.hasBeenFound == false){
            _item.hasBeenFound =true;
        }
        
        Container.Add(new InventorySlot(database.GetId[_item], _item, _amount));     
        
   }

   public void RemoveItem(ItemObject _item, int _amount)
    {
        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item.ID == _item.ID)
            {
                Debug.Log("Removing");
                Debug.Log($"ItemID: {_item.ID}, Item: {_item}");
                Container[i].RemoveAmount(_amount);

                 Debug.Log($"Item Amount: {Container[i].amount}");

                // If the amount becomes zero or less, remove the slot
                if (Container[i].amount <= 0)
                {
                    Container.RemoveAt(i);
                }

                return;
            }
        }
    }

    public bool inInvent(ItemObject _item){
        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item.ID == _item.ID)
            {
                return true;
                
            }
        }

        return false;

    }

   public void OnAfterDeserialize(){
        
        // for (int i = 1; i < Container.Count; i++){
        //     Container[i].item = database.GetItem[Container[i].ID];
        // }

    }
    public void OnBeforeSerialize(){

    }

    public void Save(){
        
        string saveData = JsonUtility.ToJson(this, true);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
        bf.Serialize(file, saveData);
        file.Close();

    }

    public void Load(){

    }
}



[System.Serializable] //class will show up in the editor in unity
public class InventorySlot{
    public ItemObject item;
    public int amount;
    public int ID;
    public InventorySlot(int _id, ItemObject _item, int _amount){
        ID = _id;
        item = _item;
        amount = _amount;
    }

    public void AddAmount(int value){
        amount += value;
    }

    public void RemoveAmount(int value)
    {
        amount -= value;
    }
   
}
