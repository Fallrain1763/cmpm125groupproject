using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClickObject : MonoBehaviour
{
    public GameObject body;
    public GameObject player;
    public List<Material> colorList = new List<Material>();
    public int currentColor = 0; // 0 = Red, 1 = Green, 2 = Blue.
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
                        hit.collider.gameObject.GetComponent<Collider>().sharedMaterial = defaultMaterial; // Reverses green
                        Physics.IgnoreCollision(hit.collider.gameObject.GetComponent<Collider>(), player.GetComponent<Collider>(), false); // Reverses blue
                        hit.collider.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
                        break;
                    case 1:
                        // Green
                        Physics.IgnoreCollision(hit.collider.gameObject.GetComponent<Collider>(), player.GetComponent<Collider>(), false); // Reverses blue
                        hit.collider.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None; // Reverses red
                        hit.collider.gameObject.GetComponent<Collider>().sharedMaterial = bouncyMaterial;
                        hit.collider.gameObject.GetComponent<Rigidbody>().useGravity = true;
                        break;
                    case 2:
                        // Blue
                        hit.collider.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None; // Reverses red
                        hit.collider.gameObject.GetComponent<Collider>().sharedMaterial = defaultMaterial; // Reverses green
                        Physics.IgnoreCollision(hit.collider.gameObject.GetComponent<Collider>(), player.GetComponent<Collider>(), true);
                        break;
                    default:
                        // White
                        hit.collider.gameObject.GetComponent<Collider>().sharedMaterial = defaultMaterial; // Reverses green
                        Physics.IgnoreCollision(hit.collider.gameObject.GetComponent<Collider>(), player.GetComponent<Collider>(), false); // Reverses blue
                        hit.collider.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None; // Reverses red
                        break;
                }
            }
        }

        //this is for testing purposes
        //Alpha1 = "1" on keyboard
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentColor = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentColor = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentColor = 2;
        }
    }
}
