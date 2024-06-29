using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
public class DisplayPopup : MonoBehaviour
{
    public GameObject popUpWindow;
    private GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CreatePopup(ItemObject selectedSlime){
        
        obj = Instantiate(popUpWindow, this.transform);
        TextMeshProUGUI[] textComponents = obj.GetComponentsInChildren<TextMeshProUGUI>();
        Image itemImage = obj.GetComponentsInChildren<Image>()[2];

        TextMeshProUGUI firstText = textComponents[0];
        TextMeshProUGUI secondText = textComponents[1];

        if(selectedSlime != null){
            firstText.text = selectedSlime.displayName;
            secondText.text = selectedSlime.description;
            itemImage.sprite = selectedSlime.icon;
        }else{
            firstText.text = "FAILURE!";
            secondText.text = "This is a useless slime that will be sacrificed to the biohazard bin.";
        }

    }
}
