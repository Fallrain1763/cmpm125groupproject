using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

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
        //references the color list and gets the color of the material
        colorbar.GetComponent<Image>().color = clickobject.colorList[clickobject.currentColor].color;
    }
}
