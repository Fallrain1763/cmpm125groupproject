using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClickObject : MonoBehaviour
{
    public GameObject body;
    public GameObject player;
    public GameObject whiteBar;
    public GameObject blueBar;
    public GameObject redBar;
    public GameObject greenBar;
    public List<Material> colorList = new List<Material>();
    public int currentColor = 0; // 0 = Blue, 1 = Red, 2 = Green.
    public PhysicMaterial bouncyMaterial;
    public PhysicMaterial defaultMaterial;
    private bool isBlue;
    private bool isRed;
    private bool isGreen;
   

    // Start is called before the first frame update
    void Start()
    {
        
        if (PlayerPrefs.GetInt("isBlue") == 0)
            isBlue = false;
        else
            isBlue = true;

        if (PlayerPrefs.GetInt("isRed") == 0)
            isRed = false;
        else
            isRed = true;

        if (PlayerPrefs.GetInt("isGreen") == 0)
            isGreen = false;
        else
            isGreen = true;   

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
                switch(currentColor) 
                {
                    case 0:
                        if (isBlue)
                        {
                            hit.collider.gameObject.GetComponent<MeshRenderer>().material = colorList[currentColor];
                            hit.collider.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None; // Reverses red
                            hit.collider.gameObject.GetComponent<Collider>().sharedMaterial = defaultMaterial; // Reverses green
                            Physics.IgnoreCollision(hit.collider.gameObject.GetComponent<Collider>(), player.GetComponent<Collider>(), true);
                        }
                        break;
                    case 1:
                        if (isRed)
                        {
                            hit.collider.gameObject.GetComponent<MeshRenderer>().material = colorList[currentColor];
                            hit.collider.gameObject.GetComponent<Collider>().sharedMaterial = defaultMaterial; // Reverses green
                            Physics.IgnoreCollision(hit.collider.gameObject.GetComponent<Collider>(), player.GetComponent<Collider>(), false); // Reverses blue
                            hit.collider.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
                        }
                        break;
                    case 2:
                        if (isGreen)
                        {
                            hit.collider.gameObject.GetComponent<MeshRenderer>().material = colorList[currentColor];
                            Physics.IgnoreCollision(hit.collider.gameObject.GetComponent<Collider>(), player.GetComponent<Collider>(), false); // Reverses blue
                            hit.collider.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None; // Reverses red
                            hit.collider.gameObject.GetComponent<Collider>().sharedMaterial = bouncyMaterial;
                            hit.collider.gameObject.GetComponent<Rigidbody>().useGravity = true;
                        }
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
            whiteBar.transform.localPosition = new Vector3(500, 490, 0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentColor = 1;
            whiteBar.transform.localPosition = new Vector3(650, 490, 0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentColor = 2;
            whiteBar.transform.localPosition = new Vector3(800, 490, 0);
        }

        if (isBlue)
            blueBar.GetComponent<Image>().color = colorList[0].color;
        if (isRed)
            redBar.GetComponent<Image>().color = colorList[1].color;
        if (isGreen)
            greenBar.GetComponent<Image>().color = colorList[2].color;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);

        if (other.gameObject.tag == "Blue")
        {
            isBlue = true;
            PlayerPrefs.SetInt("isBlue", 1);
            
        }
        else if (other.gameObject.tag == "Red")
        {
            isRed = true;
            PlayerPrefs.SetInt("isRed", 1);
        }
        else if (other.gameObject.tag == "Green")
        {
            isGreen = true;
            PlayerPrefs.SetInt("isGreen", 1);
        }
        else if (other.gameObject.tag == "L2")
        {
            SceneManager.LoadScene("Level2");
        }
        else if (other.gameObject.tag == "L3")
        {
            SceneManager.LoadScene("Level3");
        }
        else if (other.gameObject.tag == "Win")
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            SceneManager.LoadScene("Win");
        }
    }
}
