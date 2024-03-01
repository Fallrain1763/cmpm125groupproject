using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickObject : MonoBehaviour
{
    public List<Material> colorList = new List<Material>();
    public int currentColor = 0; // 0 = Red, 1 = Green, 2 = Blue, 3 = Default/White.
    public PhysicMaterial bouncyMaterial;
    public PhysicMaterial defaultMaterial;
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
                switch(currentColor) 
                {
                    case 0:
                        // Red
                        hit.collider.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
                        break;
                    case 1:
                        // Green
                        hit.collider.gameObject.GetComponent<Collider>().sharedMaterial = bouncyMaterial;
                        break;
                    case 2:
                        // Blue
                        hit.collider.gameObject.GetComponent<Rigidbody>().useGravity = false;
                        break;
                    default:
                        // White
                        hit.collider.gameObject.GetComponent<Collider>().sharedMaterial = defaultMaterial; // Reverses green
                        hit.collider.gameObject.GetComponent<Rigidbody>().useGravity = true; // Reverses blue
                        hit.collider.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None; // Reverses red
                        break;
                }
            }
        }
    }
}
