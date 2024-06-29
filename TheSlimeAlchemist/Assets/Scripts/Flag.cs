using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    public Sprite greenflag;
    public Sprite redflag;
    public SpriteRenderer render;
    public GameObject Player;
    private bool hit = false;

    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

        // Modify color of flag depending on collision
        void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
             audio.Play();
            //Debug.Log("True!");
            render.sprite = greenflag;
        }
    }

    /*    // Modify color of flag depending on collision
        void OnTriggerExit2D(Collider2D collider)
        {
            if (collider.gameObject.tag == "Player")
            {
                Debug.Log("False!");
                render.sprite = redflag;
            }
     */
}