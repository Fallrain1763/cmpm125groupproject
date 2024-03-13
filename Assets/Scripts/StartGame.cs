using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("isRed", 0);
        PlayerPrefs.SetInt("isBlue", 0);
        PlayerPrefs.SetInt("isGreen", 0);
        SceneManager.LoadScene("MainMenu");
    }
}
