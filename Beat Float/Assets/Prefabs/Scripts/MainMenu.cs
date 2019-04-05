using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("AfterGameOver");
        Time.timeScale = 1f;
        PlatformSpawner.instance.enabled = true;
    }



    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
