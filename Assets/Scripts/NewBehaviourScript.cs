using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject player;
    public GameObject cube;
    public Material blue;

    // Start is called before the first frame update
    void Start()
    {
        cube.GetComponent<MeshRenderer>().material = blue;
        Physics.IgnoreCollision(cube.GetComponent<Collider>(), player.GetComponent<Collider>(), true);
    }
}
