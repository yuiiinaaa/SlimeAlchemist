
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// </summary>
public class GameManager : MonoBehaviour {
	public static GameManager Instance;
	public InventoryObject inventory;
    public InventoryObject partyinventory;

    public ItemDatabaseObject mainDatabase;
	public ItemObject _item;

	private void Awake(){
		Instance = this;
	}

	void Start(){
		inventory.AddItem(mainDatabase.GetItem[1], 1);
		
	}

	/// <summary>
	/// This GameManager will check for input to restart the scene
	/// </summary>
	void Update(){
		if (Input.GetKeyDown (KeyCode.R)) {
			RestartTheGame ();
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}
	}
		
	/// <summary>
	/// Reloads the current scene.
	/// </summary>
	public void RestartTheGame(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	void OnApplicationQuit()
    {
        inventory.Container.Clear();
        inventory.coinAmount = 10;
        partyinventory.Container.Clear();

        mainDatabase.ResetInPartyValues();
    }

}

