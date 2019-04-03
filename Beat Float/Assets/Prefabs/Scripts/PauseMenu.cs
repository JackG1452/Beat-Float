using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPause = false;
    public GameObject pauseMenuUI;

    public void PauseFunc()
    {
     
            if (GameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();

            }
        
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = (false);
        PlatformSpawner.instance.enabled = true;

    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = (true);
        PlatformSpawner.instance.enabled = false;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("SampleScene 1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
