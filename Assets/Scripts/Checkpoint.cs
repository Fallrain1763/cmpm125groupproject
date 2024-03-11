using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
            // Keeps track of player's current position.
            RespawnPlayer.playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
            RespawnPlayer.playerRot = GameObject.FindGameObjectWithTag("Player").transform.rotation;
        }
    }
}
