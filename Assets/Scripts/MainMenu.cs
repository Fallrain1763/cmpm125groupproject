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
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
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
