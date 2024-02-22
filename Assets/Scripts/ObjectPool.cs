using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    private List<Material> pooledObjects = new List<Material>();
    //private int amountToPool = 3;

    [SerializeField] private Material redMaterial;
    [SerializeField] private Material blueMaterial;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

        Material obj1 = Instantiate(redMaterial);
        pooledObjects.Add(obj1);

        Material obj2 = Instantiate(blueMaterial);
        pooledObjects.Add(obj2);


    }
}