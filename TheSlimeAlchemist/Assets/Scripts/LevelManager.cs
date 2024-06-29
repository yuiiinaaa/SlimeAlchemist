using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public float respawnDelay;
    static string previousScene;
    static string currentScene; 

    private Transform spawnPoint;
    private Transform playerPos;

    private Player player;

    private AudioSource audioSource;
    


    void Awake()
    {
        //previousScene = SceneManager.GetActiveScene ().name;
        // makes audio manager persist between scenes
        //DontDestroyOnLoad(gameObject);

        /*
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        */
    }

    void Update(){
		if (Input.GetKeyDown (KeyCode.R)) {
			
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}
        if (Input.GetKeyDown (KeyCode.M)) {
            OpenScene("MixingScene");
			
		}
        if (Input.GetKeyDown (KeyCode.O)) {
            OpenScene("ShopScreen");
			
		}
	}


    public void OpenScene(string levelName)
    {
        previousScene = SceneManager.GetActiveScene ().name;
        SceneManager.LoadScene(levelName);

    }

    public void OpenPrevScene()
    {
        SceneManager.LoadScene(previousScene);

    }

    void Start()
    {
        //gameObject = Find("LevelManager").GetComponent<LevelManager>();
    }


    
}
