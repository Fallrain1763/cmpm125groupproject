using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariableSelector : MonoBehaviour
{
    [SerializeField]
    [Range(0, 3)]
    [Tooltip("0 is Menu, 1 is In_Game, 2 is Victory, 3 is Loss")]
    private int ContextSelector;

    [SerializeField]
    [Range(0f, 1f)]
    [Tooltip("0 is lowest, .25 is transition, .75 is transition, 1 is highest")]
    private float IntensitySelector;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Context", ContextSelector);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Intensity", IntensitySelector);
    }
}
