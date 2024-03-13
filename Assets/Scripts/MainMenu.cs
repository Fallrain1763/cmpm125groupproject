using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource soundPlayer;

    private void Start()
    {
        soundPlayer = GameObject.Find("AudioSource").GetComponent<AudioSource>();
    }

    public void ButtonSoundEffect()
    {
        soundPlayer.Play();
    }

    public void PlayGame()
    {
        PlayerPrefs.SetInt("isRed", 0);
        PlayerPrefs.SetInt("isBlue", 0);
        PlayerPrefs.SetInt("isGreen", 0);
        SceneManager.LoadScene("Level1");
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Lose");
    }

    public void GamePassed()
    {
        SceneManager.LoadScene("Win");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
