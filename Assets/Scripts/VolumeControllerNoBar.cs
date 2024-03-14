using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeControllerNoBar : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;

    public void Start()
    {
        float volume = PlayerPrefs.GetFloat("volume");
        
        myMixer.SetFloat("vol", volume);
    }
}
