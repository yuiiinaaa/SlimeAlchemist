using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBackground : MonoBehaviour
{
    public GameObject fullDisplay;


    // Start is called before the first frame update
    void Start()
    {
        var obj = Instantiate(fullDisplay, this.transform);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
