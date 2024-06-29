using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class MyPlayerObject: ScriptableObject{
//     public GameObject playerObj;
// }

public class PlayerObject : MonoBehaviour
{
   public GameObject player;
   public GameObject swapPlayer;
   private GameObject obj;

   public InventoryObject partyInventory;
   static Dictionary<int, GameObject> myPlayers = new Dictionary<int, GameObject>();
   //public ItemObject item;

   void Start(){
        //player = GetComponentsInChildren<GameObject>();
        obj = Instantiate(player);
        transform.position = obj.transform.position;
        
   }

   void Update(){
        //transform.position = obj.transform.position;
    
        if ((Input.GetKeyDown(KeyCode.Alpha1)) && (partyInventory.Container.Count >= 1)){
            swapPlayer = partyInventory.Container[0].item.playableCharacter;

        } else if ((Input.GetKeyDown(KeyCode.Alpha2)) &&(partyInventory.Container.Count >= 2)){
            swapPlayer = partyInventory.Container[1].item.playableCharacter;

        } else if ((Input.GetKeyDown(KeyCode.Alpha3)) &&(partyInventory.Container.Count >= 3)){
            swapPlayer = partyInventory.Container[2].item.playableCharacter;
        }

        if(player!= swapPlayer){
            transform.position = obj.transform.position;
        player = swapPlayer;
        Destroy(obj);
        obj = Instantiate(player, new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), Quaternion.identity);
        
        }
    
   }

   public void playerAssign(ItemObject item){
    swapPlayer = item.playableCharacter;
   }

   public GameObject getPlayer(){
    return player;
   }

}
