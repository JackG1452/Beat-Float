using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayLevel1()
    {
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1f;
        if(PlatformSpawner.instance != null)
        PlatformSpawner.instance.enabled = true;
    }

    public void PlayLevel2()
    {
        SceneManager.LoadScene("Level2");
        Time.timeScale = 1f;
        if (PlatformSpawner.instance != null)
            PlatformSpawner.instance.enabled = true;
    }
    public void PlayLevel3()
    {
        SceneManager.LoadScene("Level3");
        Time.timeScale = 1f;
        if (PlatformSpawner.instance != null)
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
