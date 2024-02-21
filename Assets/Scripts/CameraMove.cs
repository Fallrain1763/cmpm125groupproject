using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float senseH;
    public float senseV;

    float yRotation;
    float xRotation;

    public Transform cameraPosition;
    // Start is called before the first frame update
    void Awake(){
        //Use these if have an options menu that lets the player customize their sensitivity
        //senseH = PlayerPrefs.GetFloat("XSense");
        //senseV = PlayerPrefs.GetFloat("YSense");
    }
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = senseH * Input.GetAxisRaw("Mouse X") * Time.deltaTime;
        float mouseY = senseV * Input.GetAxisRaw("Mouse Y") * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        yRotation += mouseX;

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        cameraPosition.rotation = Quaternion.Euler(0, yRotation, 0);

        

        transform.position = cameraPosition.position;
    }
}
