using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickObject : MonoBehaviour
{
    public List<Color> colorList = new List<Color>();
    public int currentColor = 0; // 0 = Red, 1 = Green, 2 = Blue.
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        // Uses raycast to detect if raycast is facing clickable object.
        if(Physics.Raycast(body.transform.position, body.transform.forward, out hit, 20.0f))
        {
            //Debug.DrawRay(transform.position, transform.forward*5, Color.red, 1.0f, true);
            //Debug.Log(hit.collider.gameObject.name);
            if(hit.collider.gameObject.CompareTag("Paintable") && Input.GetButtonDown("Fire1"))
            {
                //Debug.Log("OBJECT HIT");
                hit.collider.gameObject.GetComponent<MeshRenderer>().material = colorList[currentColor];
            }
        }
    }
}
