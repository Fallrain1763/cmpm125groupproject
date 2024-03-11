using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    static public RespawnPlayer instance;
    static public Vector3 playerPos;
    static public Quaternion playerRot;
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
            // Saves player's current position.
            Debug.Log("Trigger enter");
            GameObject.FindGameObjectWithTag("Player").transform.position = playerPos;
            GameObject.FindGameObjectWithTag("Player").transform.rotation = playerRot;
        }
    }
}
