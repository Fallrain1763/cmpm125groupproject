using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDColor : MonoBehaviour
{
    public GameObject colorbar;
    [SerializeField] ClickObject clickobject;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // this changes the color of the bar 
        // Note: This is inefficient especially when we will have multiple colors
        // Will try to go back and change it to get material color instead of referencing currentcolor
        // in ClickObject.CS and manually adding it. - Brandon

        // Red
        if (clickobject.currentColor == 0)
            colorbar.GetComponent<Image>().color = new Color32(236, 8, 8, 255);
        // Green
        if (clickobject.currentColor == 1)
            colorbar.GetComponent<Image>().color = new Color32(93, 255, 0, 255);
        // Blue
        if (clickobject.currentColor == 2)
            colorbar.GetComponent<Image>().color = new Color32(17, 16, 225, 226);

    }
}
