using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    public Vector3 playerPos;
    public Quaternion playerRot;
    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        playerRot = GameObject.FindGameObjectWithTag("Player").transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        // Checks if player entered the respawn trigger.
        if (collision.gameObject.CompareTag("Player"))
        {
            // Returns player to starting position.
            //GameObject.Find("Player").GetComponent<Rigidbody>().velocity = Vector3.zero;
            //GameObject.Find("Player").GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            Debug.Log("Trigger enter");
            GameObject.FindGameObjectWithTag("Player").transform.position = playerPos;
            GameObject.FindGameObjectWithTag("Player").transform.rotation = playerRot;
        }
    }
}
