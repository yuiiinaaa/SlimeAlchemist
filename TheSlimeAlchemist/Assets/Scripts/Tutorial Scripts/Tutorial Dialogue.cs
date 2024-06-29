using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialDialogue : MonoBehaviour
{
   public TextMeshProUGUI dialogue;

    private int currentLine = 0;
    private static bool initalDialogue = false;
    private static bool slimeDialogue = false;
    private static bool coinDialogue = false;     
    private static bool fireDialogue = false;
    private static bool lastDialogue = false;

    private static bool popupEnabled = true;

    AudioSource audio;

    private string[] initialLines = {   "You are a slime in a petri dish!",
                                "Use the arrow keys to move and spacebar to jump...",
                                "... and the little flags are the respawning points!",
                                "Collect your first slime!"
                             };

    private string[] metSlimeLines = {  "Click 'I' to see your inventory, and 'P' to see your party of slimes!",
                                "You can also switch between slime characters using the keys '1', '2', and '3'.",
                                "Click the slimes to add them to your party!",
                            };

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        player = GameObject.FindWithTag("Player");
        if (player != null)
        {
           // Debug.Log("Found player: " + player.name);
        }
        dialogue.text = "Welcome to The Slime Alchemist!";
        StartDialogue();

    }


    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindWithTag("Player2");
        // First Dialogue
        if (Input.GetKeyDown(KeyCode.Z) && initalDialogue)
        {
            audio.Play();
            if (currentLine < initialLines.Length)
            {
                dialogue.text = initialLines[currentLine];
                currentLine++;
            }
            else
            {
                // End of dialogue
                dialogue.text = "";
                initalDialogue = false;
            }
        }

        // Second Dialogue after meeting Oxygen
        if(/*player.GetComponent<Player>() != null &&*/ player.GetComponent<Player>().metOxy)
        {
            //Debug.Log("MetSlime!");
            MetSlime();
            dialogue.text = "You collected your first slime: Oxygen!";
            player.GetComponent<Player>().metOxy = false;

        }

        if (Input.GetKeyDown(KeyCode.Z) && slimeDialogue)
        {
            audio.Play();
            if (currentLine < metSlimeLines.Length)
            {
                Debug.Log("following texts...");
                dialogue.text = metSlimeLines[currentLine];
                currentLine++;
            }
            else
            {
                // End of dialogue
                dialogue.text = "";
                slimeDialogue = false;
            }
        }

        // Coin Dialogue after getting coin
        if (/*player.GetComponent<Player>() != null &&*/ player.GetComponent<Player>().gotCoin)
        {
            Debug.Log("Got Coin!");
            GotCoin();
            dialogue.text = "You got a coin! You can use coins to buy more slimes!";
            player.GetComponent<Player>().gotCoin = false;

        }

        if (Input.GetKeyDown(KeyCode.Z) && coinDialogue)
        {
            audio.Play();
            // End of dialogue
            dialogue.text = "";
                coinDialogue = false;
        }

        // Fire Dialogue after touching flame
        if (player.GetComponent<Player>() != null && player.GetComponent<Player>().touchedFire)
        {
            Debug.Log("Touched Fure!");
            TouchedFire();
            dialogue.text = "Oh no! You touched the fire: whenever you die, you will be respawned to the last respawn point.";
            player.GetComponent<Player>().touchedFire = false;

        }

        if (Input.GetKeyDown(KeyCode.Z) && fireDialogue)
        {
            audio.Play();
            // End of dialogue
            dialogue.text = "";
            coinDialogue = false;
        }
       
        // Last Dialogue after reaching door
        if (player.GetComponent<Player>() != null && player.GetComponent<Player>().reachedDoor)
        {
            Debug.Log("Reached Door!");
            ReachedDoor();
            dialogue.text = "Press the Space bar to get to the next level!";
            player.GetComponent<Player>().reachedDoor = false;

        }

        if (Input.GetKeyDown(KeyCode.Space) && lastDialogue)
        {
            audio.Play();
            // Go to next level
            player.GetComponent<Player>().NextScene();
        }
    }

    public void StartDialogue()
    {
        initalDialogue = true;
        currentLine = 0;
    }

    public void MetSlime()
    {
        slimeDialogue = true;
        currentLine = 0;
        Debug.Log("currentLine: " + currentLine + ", metSlimesLines: " + metSlimeLines.Length);
    }

    public void GotCoin()
    {
        coinDialogue = true;
        currentLine = 0;
    }

    public void TouchedFire()
    {
        fireDialogue = true;
        currentLine = 0;
    }


    public void ReachedDoor()
    {
        lastDialogue = true;
        currentLine = 0;
    }
}

// change font and textbox