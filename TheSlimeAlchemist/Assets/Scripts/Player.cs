using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public InventoryObject inventory;
    public InventoryObject partyinventory;

    public ItemDatabaseObject mainDatabase;

    // for respawning
    public Vector3 respawnPoint;

    // for the tutorial dialogue
    public bool gotCoin = false;
    public bool metOxy = false;
    public bool touchedFire = false;
    public bool reachedDoor = false;

    public string ability;

    AudioSource audio;

    // for next scene
    private GameObject levelManager;
    public string nextScene;
    public GameObject canvas;
    static GameObject tempCanvas;

    void Start()
    {
        levelManager = GameObject.FindWithTag("GameController");
        if (levelManager != null)
        {
            Debug.Log("Found levelManager: " + levelManager.name);
        }
        // initial respawn point is start position of player
        respawnPoint = transform.position;

        audio = GetComponent<AudioSource>();

        // playerAnimation = GetComponent<Animator>();

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            metOxy = true;
            Debug.Log("Hit object: " + other.GetComponent<Collider2D>().gameObject.name);
            //Debug.Log("metOxy: " + metOxy);

            if (other != null)
            {
                var item = other.GetComponent<Item>();
                if (item)
                {   
                    //Vector2 spawnPos = Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 0.5f));
                    //tempCanvas = Instantiate(canvas, spawnPos, Quaternion.identity);
                    //Debug.Log(tempCanvas);
                    //tempCanvas.GetComponent<DisplayPopup>().CreatePopup(item.item);
                    inventory.AddItem(item.item, 1);
                    Destroy(other.gameObject);
                }
            }
        }

        if (other.gameObject.CompareTag("Coin"))
        {
            //audio.Play();
            gotCoin = true;
            Debug.Log("Hit object: " + other.GetComponent<Collider2D>().gameObject.name);

            if (other != null)
            {
                var item = other.GetComponent<Item>();
                if (item)
                {
                    inventory.AddCoinAmount(1);
                    Destroy(other.gameObject);
                }

            }
        }

        if (other.gameObject.CompareTag("ENEMY"))
        {
            if(ability == "WATER"){
                Destroy(other.gameObject);
            }else{
                touchedFire = true;
                Respawn();
                 }
        }

        if (other.gameObject.CompareTag("Respawn"))
        {
            Debug.Log("Respawn point: " + transform.position);
            respawnPoint = GameObject.FindGameObjectWithTag("Respawn").transform.position;

        }

        if (other.gameObject.CompareTag("Door"))
        {
            Debug.Log("Reached door");
            reachedDoor = true;

        }

    }

    public void Respawn()
    {
        transform.position = respawnPoint;
    }

    public void NextScene()
    {
        levelManager.GetComponent<LevelManager>().OpenScene(nextScene);
    }


    // void OnApplicationQuit()
    // {
    //     inventory.Container.Clear();
    //     inventory.coinAmount = 10;
    //     partyinventory.Container.Clear();

    //     mainDatabase.ResetInPartyValues();
    // }
}