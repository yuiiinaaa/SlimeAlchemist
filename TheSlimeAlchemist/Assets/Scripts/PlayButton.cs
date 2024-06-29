using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{

    private AudioSource audioSource;

    private void Start()
    {

    }
    private void Awake()
    {
        /*
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource != null)
        {
            Debug.Log("Audio found");
        }
        else
        {
            Debug.Log("Audio not found");
        }
        DontDestroyOnLoad(gameObject);
        */
    }

    /*
     * void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.Play();
        }
    }
    */

    /*
    public static AudioSource audio = gameObject.GetComponent<AudioSource>();

    void Awake()
    {

        // makes audio manager persist between scenes
        DontDestroyOnLoad(gameObject);

        if (audio == null)
                   audio = gameObject.GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
            return;

        }
    }
    */
}
